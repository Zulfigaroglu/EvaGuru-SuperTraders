using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SuperTraders.Infrastructure
{
    public class TokenGenerator: IDisposable
    {
        private const string _tokenKey = "adshjbsdkjbhfkjashfkjnjasklfjlas";
        public DateTime _startTime;
        public DateTime _endTime;
        public List<Claim> _claims = new List<Claim>();
        private JwtSecurityTokenHandler _mainJwtSecurityTokenHandler = null;

        public TokenGenerator()
        {
            _mainJwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public void SplitToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", "");
                byte[] key = Encoding.ASCII.GetBytes(_tokenKey);
                TokenValidationParameters validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                ClaimsPrincipal claims = _mainJwtSecurityTokenHandler.ValidateToken(token, validations, out var tokenSecure);
                for (int i = 0; i < claims.Identities.Count(); i++)
                {
                    foreach (var claim in claims.Identities.First().Claims)
                    {
                        if (claim.Type == "exp")
                        {
                            long exp = long.Parse(claim.Value);
                            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(exp);
                            _endTime = dateTimeOffset.DateTime.ToLocalTime();
                        }
                        else if (claim.Type == "iat")
                        {
                            long ict = long.Parse(claim.Value);
                            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ict);
                            _startTime = dateTimeOffset.DateTime.ToLocalTime();
                        }
                        else if (claim.Type == "nbf")
                        {
                            //  _endTime = DateTime.Parse(_claim.Value);
                        }
                        else
                        {
                            _claims.Add(claim);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddClaim(string key, string value)
        {
            Claim tmpClaim = new Claim(key, value);
            _claims.Add(tmpClaim);
        }

        public bool IsPublicToken()
        {
            try
            {
                if (_claims.FirstOrDefault(clm => clm.Type == "Public") != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateToken(string claimType = "", int endDay = 30)
        {
            _startTime = DateTime.Now;
            _endTime = DateTime.Now.AddDays(endDay);
            byte[] key = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor mainSecurityTokenDescriptor = new SecurityTokenDescriptor();
            mainSecurityTokenDescriptor.Subject = new ClaimsIdentity();
            foreach (Claim tmpClaim in _claims)
            {
                mainSecurityTokenDescriptor.Subject.AddClaim(tmpClaim);
            }

            mainSecurityTokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, claimType));
            mainSecurityTokenDescriptor.IssuedAt = _startTime;
            mainSecurityTokenDescriptor.Expires = _endTime;
            mainSecurityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);
            SecurityToken token = _mainJwtSecurityTokenHandler.CreateToken(mainSecurityTokenDescriptor);
            return "Bearer " + _mainJwtSecurityTokenHandler.WriteToken(token);
        }

        public void Dispose()
        {
        }
    }
}
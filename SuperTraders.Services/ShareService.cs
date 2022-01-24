using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Infrastructure;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Services
{
    public class ShareService: IShareService
    {
        private readonly IUserRepository UserRepository;

        public ShareService(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public Task<ICollection<Share>> All()
        {
            throw new NotImplementedException();
        }
    }
}
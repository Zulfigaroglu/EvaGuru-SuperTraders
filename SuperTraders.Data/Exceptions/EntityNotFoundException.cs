using System;

namespace SuperTraders.Presentation.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Message
        {
            get => "İstenen kayıt veritabanında bulunamadı!";
        }
    }
}
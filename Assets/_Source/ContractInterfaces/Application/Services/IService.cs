using System;

namespace ContractInterfaces.Application.Services
{
    public interface IService : IDisposable
    {
        public void Initialize();
    }
}
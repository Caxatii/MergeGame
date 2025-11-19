using System;

namespace _Source.ContractInterfaces.Application
{
    public interface IService : IDisposable
    {
        public void Initialize();
    }
}
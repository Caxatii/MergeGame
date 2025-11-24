using System;

namespace ContractInterfaces.Application.Services
{
    public interface IGridRandomPlaceUseCase : IService
    {
        public void Spawn(Guid id);
    }
}
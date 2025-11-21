using ContractInterfaces.Domain;

namespace Domain.Grid.Cells
{
    public struct Cell<T> : ICell
    {
        public readonly T Data;

        public Cell(T data)
        {
            Data = data;
        }

        public bool IsEmpty =>
            Data == null;
    }
}
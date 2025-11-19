using _Source.ContractInterfaces.Domain;

namespace _Source.Domain
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
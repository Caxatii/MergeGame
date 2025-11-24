using System;

namespace Infrastructure
{
    public struct UnorderedGuidPair : IEquatable<UnorderedGuidPair>
    {
        public readonly Guid First;
        public readonly Guid Second;

        public UnorderedGuidPair(Guid first, Guid second)
        {
            if (first.CompareTo(second) <= 0)
            {
                First = first;
                Second = second;
            }
            else
            {
                First = second;
                Second = first;
            }
        }

        public bool Equals(UnorderedGuidPair other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public override bool Equals(object obj)
        {
            return obj is UnorderedGuidPair other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash1 = First.GetHashCode();
                int hash2 = Second.GetHashCode();

                return (hash1 * 397) ^ (hash2 * 397);
            }
        }

        public static bool operator !=(UnorderedGuidPair left, UnorderedGuidPair right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(UnorderedGuidPair left, UnorderedGuidPair right)
        {
            return left.Equals(right);
        }

        public override string ToString()
        {
            return $"({First}, {Second})";
        }

        public static implicit operator UnorderedGuidPair((Guid, Guid) tuple)
        {
            return new UnorderedGuidPair(tuple.Item1, tuple.Item2);
        }
    }
}
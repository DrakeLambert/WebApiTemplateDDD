using System.Collections.Generic;
using System.Linq;

namespace WebApiTemplateDDD.Core.BuildingBlocks
{
    public abstract class Equatable
    {
        public override bool Equals(object obj)
        {
            // Is null?
            if (obj is null)
            {
                return false;
            }

            // Is the same object?
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // Is the same type?
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return IsEqual((Equatable)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int hashSeed = (int)2166136261;
                const int hashMultiplier = 16777619;

                return GetAtomicValues()
                    .Aggregate(hashSeed, (hash, value) =>
                         (hash * hashMultiplier) ^ value?.GetHashCode() ?? 0
                    );
            }
        }

        public static bool operator ==(Equatable left, Equatable right)
        {
            // Ensure that left isn't null
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Equatable left, Equatable right)
        {
            return !(left == right);
        }

        private bool IsEqual(Equatable obj) =>
            GetAtomicValues().SequenceEqual(obj.GetAtomicValues());

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}

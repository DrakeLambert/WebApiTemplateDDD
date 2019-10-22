using System.Collections.Generic;

namespace WebApiTemplateDDD.Core.BuildingBlocks
{
    public abstract class Entity : Equatable
    {
        public override string ToString()
        {
            return $"{GetType().Name} {GetId()}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return GetId();
        }

        protected abstract object GetId();
    }
}

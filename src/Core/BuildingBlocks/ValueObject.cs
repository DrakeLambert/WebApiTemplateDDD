using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WebApiTemplateDDD.Core.BuildingBlocks
{
    public abstract class ValueObject : Equatable
    {
        public override string ToString()
        {
            return $"{GetType().Name} {JsonSerializer.Serialize(this)}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return GetType()
                .GetProperties()
                .Where(prop => prop.CanRead)
                .OrderBy(prop => prop.Name)
                .Select(prop => prop.GetValue(this));
        }
    }
}

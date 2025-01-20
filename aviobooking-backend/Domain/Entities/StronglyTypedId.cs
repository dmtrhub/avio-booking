using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public readonly struct StronglyTypedId<T>
    {
        public Guid Value { get; }

        public StronglyTypedId(Guid value)
        {
            Value = value != Guid.Empty ? value : throw new ArgumentException("ID cannot be empty.");
        }

        public static StronglyTypedId<T> NewId() => new StronglyTypedId<T>(Guid.NewGuid());

        public override string ToString() => Value.ToString();

        public static bool TryParse(string? input, out StronglyTypedId<T> stronglyTypedId)
        {
            if (Guid.TryParse(input, out var guid))
            {
                stronglyTypedId = new StronglyTypedId<T>(guid);
                return true;
            }

            stronglyTypedId = default;
            return false;
        }

        public override bool Equals(object? obj) => obj is StronglyTypedId<T> other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(StronglyTypedId<T> left, StronglyTypedId<T> right) => left.Equals(right);

        public static bool operator !=(StronglyTypedId<T> left, StronglyTypedId<T> right) => !(left == right);
    }

}

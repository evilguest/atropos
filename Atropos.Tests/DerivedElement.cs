using System;
using System.Collections.Generic;
using System.Text;

namespace Atropos.Tests
{
    public class DerivedElement: BaseElement
    {
        public int Size { get; }
        //public DerivedElement() { }
        public DerivedElement(string name, int size) : base(name) => Size = size;
        public void Deconstruct(out string name, out int size) => (name, size) = (Name, Size);
        public override int GetHashCode() => base.GetHashCode() ^ Size;
        public override bool Equals(object obj) => (obj.GetType() == typeof(DerivedElement))
                && ((DerivedElement)obj).Name == Name && ((DerivedElement)obj).Size == Size;

        public override string ToString() => $"DerivedElement({Name}, {Size})";
    }
}

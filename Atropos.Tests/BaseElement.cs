using System;
using System.Collections.Generic;
using System.Text;

namespace Atropos.Tests
{
    public class BaseElement 
    {
        public string Name { get; }
        //public BaseElement() => Name = "";
        public BaseElement(string name) => Name = name;
        public void Deconstruct(out string name) => name = Name;
        public override bool Equals(object obj) 
            => (obj.GetType() == typeof(BaseElement)) && ((BaseElement)obj).Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
        
        public override string ToString() => $"BaseElement({Name})";
    }
}

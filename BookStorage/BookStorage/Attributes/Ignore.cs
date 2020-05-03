using System;

namespace BookStorage.Attributes
{
    sealed class Ignore: Attribute
    {
        public bool isIgnore { get; set; }

        public Ignore(bool isIgnore)
        {
            this.isIgnore = isIgnore;
        }       
    }
}

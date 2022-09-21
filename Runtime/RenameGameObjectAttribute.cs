using System;

namespace Kogane
{
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class RenameGameObjectAttribute : Attribute
    {
        public string Name { get; }

        public RenameGameObjectAttribute() : this( null )
        {
        }

        public RenameGameObjectAttribute( string name )
        {
            Name = name;
        }
    }
}
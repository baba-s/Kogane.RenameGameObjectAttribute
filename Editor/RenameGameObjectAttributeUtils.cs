using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class RenameGameObjectAttributeUtils
    {
        static RenameGameObjectAttributeUtils()
        {
            ObjectFactory.componentWasAdded -= OnComponentWasAdded;
            ObjectFactory.componentWasAdded += OnComponentWasAdded;
        }

        private static void OnComponentWasAdded( Component component )
        {
            Rename( component );
        }

        private static void Rename( Component component )
        {
            var type      = component.GetType();
            var attribute = type.GetCustomAttribute<RenameGameObjectAttribute>( true );

            if ( attribute == null ) return;

            var name       = attribute.Name ?? type.Name;
            var gameObject = component.gameObject;

            Undo.RecordObject( gameObject, "Rename" );

            gameObject.name = name;
        }
    }
}
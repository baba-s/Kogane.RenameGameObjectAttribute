using System;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	[InitializeOnLoad]
	internal static class RenameGameObjectAttributeUtils
	{
		private static readonly Type ATTRIBUTE_TYPE = typeof( RenameGameObjectAttribute );

		static RenameGameObjectAttributeUtils()
		{
			ObjectFactory.componentWasAdded += OnComponentWasAdded;
		}

		private static void OnComponentWasAdded( Component component )
		{
			Rename( component );
		}

		private static void Rename( Component component )
		{
			var type       = component.GetType();
			var attributes = type.GetCustomAttributes( ATTRIBUTE_TYPE, true );

			if ( attributes.Length <= 0 ) return;

			var name       = type.Name;
			var gameObject = component.gameObject;

			Undo.RecordObject( gameObject, "Rename" );

			gameObject.name = name;
		}
	}
}
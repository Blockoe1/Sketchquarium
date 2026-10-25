/*****************************************************************************
// File Name : SerializedInterface.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Generic class that allows for "serialization" of an object with a given interface.
*****************************************************************************/
using System;
using UnityEngine;

namespace AriUtils
{
    [Serializable]
    public abstract class SerializedInterface
    {
        public abstract Type InterfaceType { get; }
    }

    [Serializable]
    public class SerializedInterface<T> : SerializedInterface, ISerializationCallbackReceiver where T : class
    {
        [SerializeReference] private T _managedReferenceValue;
        [SerializeField] private UnityEngine.Object _objectReferenceValue;
        [SerializeField] private bool _referenceType; // True for managed reference, false for object reference

        public T Interface { get; set; }

        public override Type InterfaceType => typeof(T);

        public void OnAfterDeserialize()
        {
            // Stores the interface in a private variable that can be edited at runtime.
            Interface = _referenceType ? _managedReferenceValue : _objectReferenceValue as T;
        }

        public void OnBeforeSerialize() { } // Nothing extra here.

        public static implicit operator T(SerializedInterface<T> obj)
        {
            return obj.Interface;
        }
    }
}

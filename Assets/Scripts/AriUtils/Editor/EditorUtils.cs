/*****************************************************************************
// File Name : EditorUtils.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Set of common editor utility functions.
*****************************************************************************/
using System;
using UnityEditor;
using UnityEngine;

namespace AriUtils.Editor
{
    public static class EditorUtils
    {
        /// <summary>
        /// Checks if two types are the same or if they are subclasses of each other.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool IsClassOrSubclass(Type t1, Type t2)
        {
            return t1 == t2 || t1.IsSubclassOf(t2) || t2.IsSubclassOf(t1);
        }
    }
}

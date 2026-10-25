/*****************************************************************************
// File Name : ClassDropdownAttributeDrawer.cs
// Author : Arcadia Koederitz
// Creation Date : 12/30/2025
// Last Modified : 12/30/2025
//
// Brief Description : Attribute for making a sublass based dropdown for a SerializedReference field
*****************************************************************************/
using System;
using UnityEditor;
using UnityEngine;

namespace AriUtils.Editor
{
    [CustomPropertyDrawer(typeof(ClassDropdownAttribute))]
    public class ClassDropdownAttributeDrawer : PropertyDrawer
    {
        private EditorClassDropdown editorDropdown;

        /// <summary>
        /// Draws the class dropdown and relevant properties, if any.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Perform initialization if we haven't already.
            if (editorDropdown == null)
            {
                ClassDropdownAttribute dda = (attribute as ClassDropdownAttribute);
                Type baseType = GetClassType();
                bool ClassFilter(Type type)
                {
                    return EditorUtils.IsClassOrSubclass(baseType, type);
                }

                editorDropdown = new EditorClassDropdown(ClassFilter, property, dda.RestrictAssemblies ? baseType : null);
           }

            editorDropdown.DrawDropdown(position, position, property, label);
        }

        /// <summary>
        /// Specifies the total height taken up by this property.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorClassDropdown.GetSubclassPropertyHeight(property);
        }

        private Type GetClassType()
        {
            Type baseType = fieldInfo.FieldType;
            if (baseType.HasElementType)
            {
                baseType = baseType.GetElementType();
            }
            return baseType;
        }
    }
}


// Filter by allowed and excluded types.
//if (dda.ExcludedTypes != null)
//{
//    bool isExcluded = false;
//    foreach(Type et in dda.ExcludedTypes)
//    {
//        if (IsClassOrSubclass(et, type))
//        {
//            isExcluded = true;
//            break;
//        }
//    }
//    if (isExcluded)
//    {
//        continue;
//    }
//}
//if (dda.AllowedTypes != null)
//{
//    bool isAllowed = false;
//    foreach (Type at in dda.AllowedTypes)
//    {
//        if (IsClassOrSubclass(at, type))
//        {
//            isAllowed = true;
//            break;
//        }
//    }
//    if (!isAllowed)
//    {
//        continue;
//    }
//}
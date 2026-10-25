/*****************************************************************************
// File Name : SettingControl.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Generic class that serves as the base for all UI Setting controls.
*****************************************************************************/
using UnityEngine;

namespace AriUtils.UISettings
{
    public abstract class SettingControl<T> : MonoBehaviour
    {
        protected abstract string PlayerPrefsKey { get; }
        protected abstract T DefaultValue { get; }
        protected virtual void Initialize() { }

        public abstract void SetSettingValue(T value);
        protected abstract void OnValueChanged(T value);
    }
}

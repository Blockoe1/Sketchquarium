/*****************************************************************************
// File Name : DropdownSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a discrete integer/enum setting with a dropdown.
*****************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AriUtils.UISettings
{
    public abstract class DropdownSetting : SettingControl<int>
    {
        [SerializeField] protected Dropdown _dropdown;

        protected abstract int OptionLength { get; }

        private void Awake()
        {
            Initialize();

            // Setup the dropdown.
            int currentValue = -1;
            if (PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                currentValue = PlayerPrefs.GetInt(PlayerPrefsKey);
            }
            if (currentValue >= OptionLength)
            {
                currentValue = -1;
            }

            _dropdown.ClearOptions();
            List<string> options = InitializeOptions(ref currentValue);
            _dropdown.AddOptions(options);

            SetSettingValue(currentValue);
            _dropdown.SetValueWithoutNotify(currentValue);
            _dropdown.RefreshShownValue();
        }


        // Automatically subscribe/unsubscribe the setting.
        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(SetSettingValue);
        }
        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(SetSettingValue);
        }

        protected abstract List<string> InitializeOptions(ref int startingValue);
     

        public sealed override void SetSettingValue(int value)
        {
            OnValueChanged(value);
            PlayerPrefs.SetInt(PlayerPrefsKey, value);
        }
    }
}

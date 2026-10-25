/*****************************************************************************
// File Name :  SliderSetting.cs
// Author : Arcadia Koederitz
// Creation Date : 10/24/2026
// Last Modified : 10/24/2026
//
// Brief Description : Controls a setting through a slider.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace AriUtils.UISettings
{
    public abstract class SliderSetting : SettingControl<float>
    {
        [SerializeField] protected Slider _slider;

        private void Awake()
        {
            Initialize();

            float value = PlayerPrefs.GetFloat(PlayerPrefsKey, DefaultValue);
            SetSettingValue(value);
            _slider.SetValueWithoutNotify(value);
        }


        // Automatically subscribe/unsubscribe the setting.
        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(SetSettingValue);
        }
        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(SetSettingValue);
        }

        public sealed override void SetSettingValue(float value)
        {
            OnValueChanged(value);
            PlayerPrefs.SetFloat(PlayerPrefsKey, value);
        }
    }
}

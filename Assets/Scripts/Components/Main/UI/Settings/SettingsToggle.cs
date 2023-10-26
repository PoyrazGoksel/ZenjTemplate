using Extensions.Unity.MonoHelper;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Main.UI.Settings
{
    public class SettingsToggle : EventListenerMono
    {
        [SerializeField] private string _playerPrefsKey = string.Empty;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _offClip;
        [SerializeField] private AnimationClip _onClip;

        private void Awake()
        {
            if (_playerPrefsKey == string.Empty)
            {
                Debug.LogError("PlayerPrefsKey is empty.");
                enabled = false;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _toggle.isOn = PlayerPrefs.GetInt(_playerPrefsKey, 1) == 1;
        }

        protected override void RegisterEvents()
        {
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool arg0)
        {
            _animator.CrossFadeInFixedTime(arg0 ? _onClip.name : _offClip.name, 0.25f);
            PlayerPrefs.SetInt(_playerPrefsKey, arg0 ? 1 : 0);
        }

        protected override void UnRegisterEvents()
        {
            _toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}

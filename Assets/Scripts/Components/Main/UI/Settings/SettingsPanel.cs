using Events.External;
using Extensions.Unity.MonoHelper;
using Zenject;

namespace Components.Main.UI.Settings
{
    public class SettingsPanel : UIPanel
    {
        [Inject] private PanelEvents PanelEvents { get; set; }
        [Inject] private UIEvents UIEvents { get; set; }
        
        protected override void RegisterEvents()
        {
            base.RegisterEvents();
            PanelEvents.SettingsPanelSetActive += OnSettingsPanelSetActive;
            UIEvents.SettingsButton += OnSettingsButton;
        }

        private void OnSettingsButton()
        {
            SetActive(true);
        }

        private void OnSettingsPanelSetActive(bool arg0)
        {
            SetActive(arg0);
        }

        protected override void UnRegisterEvents()
        {
            base.UnRegisterEvents();
            PanelEvents.SettingsPanelSetActive -= OnSettingsPanelSetActive;
            UIEvents.SettingsButton -= OnSettingsButton;
        }
    }
}
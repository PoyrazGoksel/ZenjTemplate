using Events.External;
using Extensions.Unity.MonoHelper;
using Zenject;

namespace Components.Main.UI.Settings
{
    public class SettingsCloseBUT : UIButtonIMG
    {
        [Inject] private PanelEvents PanelEvents { get; set; }
        
        protected override void OnClick()
        {
            PanelEvents.SettingsPanelSetActive?.Invoke(false);
        }
    }
}
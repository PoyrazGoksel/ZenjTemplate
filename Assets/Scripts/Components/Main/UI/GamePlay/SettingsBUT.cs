using Events.External;
using Extensions.Unity.MonoHelper;
using Zenject;

namespace Components.Main.UI.GamePlay
{
    public class SettingsBUT : UIButtonIMG
    {
        [Inject] private UIEvents UIEvents { get; set; }


        protected override void OnClick()
        {
            UIEvents.SettingsButton?.Invoke();
        }
    }
}

using Extensions.Unity.MonoHelper;
using Application = UnityEngine.Device.Application;

namespace Components.Main.UI.Settings
{
    public class SettingsHomeBUT : UIButtonTMP
    {
        protected override void OnClick()
        {
            Application.OpenURL("https://www.zinkygames.com/");
        }
    }
}

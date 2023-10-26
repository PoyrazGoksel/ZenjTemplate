using Extensions.Unity.MonoHelper;
using UnityEngine.Device;

namespace Components.Main.UI.Settings
{
    public class PrivacyBUT : UIButtonTMP
    {
        protected override void OnClick()
        {
            Application.OpenURL("https://www.zinkygames.com/privacy-policy");
        }
    }
}

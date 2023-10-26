using Extensions.Unity.MonoHelper;
using UnityEngine;

namespace Components.Main.UI.Settings
{
    public class ContactBUT : UIButtonTMP
    {
        protected override void OnClick()
        {
            Application.OpenURL("mailto:info@zinkygames.com");
        }
    }
}

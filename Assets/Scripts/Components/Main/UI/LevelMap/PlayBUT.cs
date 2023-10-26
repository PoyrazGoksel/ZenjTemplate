using Events.External;
using Extensions.Unity.MonoHelper;
using Zenject;

namespace Components.Main.UI.LevelMap
{
    public class PlayBUT : UIButtonTMP
    {
        [Inject] private UIEvents UIEvents { get; set; }

        protected override void OnClick()
        {
            UIEvents.PlayButton?.Invoke();
        }
    }
}

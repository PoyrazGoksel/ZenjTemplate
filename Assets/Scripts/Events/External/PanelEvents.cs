using JetBrains.Annotations;
using UnityEngine.Events;

namespace Events.External
{
    
    [UsedImplicitly]
    public class PanelEvents
    {
        public UnityAction<bool> LevelMapPanelSetActive;
        public UnityAction<bool> WinPanelSetActive;
        public UnityAction<bool> FailPanelSetActive;
        public UnityAction<bool> GamePlayPanelSetActive;
        public UnityAction<bool> ShopSetActive;                 
        public UnityAction<bool> ChallengePanelSetActive;
        public UnityAction<bool> SettingsPanelSetActive;
    }
}
using JetBrains.Annotations;
using UnityEngine.Events;

namespace Events.External
{
    [UsedImplicitly]
    public class MonetizationEvents
    {
        public UnityAction<bool> HideBannerAd;
        public UnityAction<bool> ShowAd;
        public UnityAction<bool> ShowBannerAd;
        public UnityAction<bool, UnityAction<bool>> ShowRewardedAd;
    }
}
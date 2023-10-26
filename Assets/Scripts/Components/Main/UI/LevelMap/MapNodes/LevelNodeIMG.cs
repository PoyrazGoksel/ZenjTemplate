using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using UnityEngine;

namespace Components.Main.UI.LevelMap.MapNodes
{
    public class LevelNodeIMG : UIIMG, ITweenContainerBind
    {
        public ITweenContainer TweenContainer { get; set; }
        [SerializeField] private Transform _myTransform;

        private void Awake()
        {
            TweenContainer = TweenContain.Install(this);
        }

        public void DoYoYo()
        {
            TweenContainer.AddTween = _myTransform.DoYoYo(1.2f, 0.5f);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            TweenContainer.Clear();
        }
    }
}

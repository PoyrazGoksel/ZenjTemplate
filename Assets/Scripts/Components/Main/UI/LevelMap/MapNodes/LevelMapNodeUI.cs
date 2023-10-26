using System;
using Extensions.DoTween;
using Extensions.Unity;
using Extensions.Unity.MonoHelper;
using UnityEngine;

namespace Components.Main.UI.LevelMap.MapNodes
{
    public class LevelMapNodeUI : UIPanel, IPoolObj, ITweenContainerBind
    {
        public ITweenContainer TweenContainer { get; set; }
        
        [SerializeField] private PathLine _leftPathLine;
        [SerializeField] private PathLine _rightPathLine;
        [SerializeField] private PathLine _topPathLine;
        [SerializeField] private PathLine _bottomPathLine;
        [SerializeField] private LevelIndexTMP _levelIndexTMP;
        [SerializeField] private LeftLevelFeature _leftLevelFeature;
        [SerializeField] private RightLevelFeature _rightLevelFeature;
        [SerializeField] private LevelNodeIMG _levelNodeIMG;
        
        MonoPool IPoolObj.MyPool { get; set; }

        private void Awake()
        {
            TweenContainer = TweenContain.Install(this);
        }

        void IPoolObj.AfterCreate() {}

        void IPoolObj.BeforeDeSpawn() {}

        void IPoolObj.TweenDelayedDeSpawn(Func<bool> onComplete) {}

        void IPoolObj.AfterSpawn() {}

        protected override void OnDisable()
        {
            base.OnDisable();
            TweenContainer.Clear();
        }

        /// <param name="isActive">Is visible?*/</param>
        /// <param name="pLevel">Current level of player not zero indexed</param>
        /// <param name="levelIndex">To be able to draw paths and write level index txt accordingly</param>
        /// <param name="isBossLevel">Changes panel visuals to boss level map node visuals</param>
        /// <param name="levelFeatureInfoArgs"> Upcoming feature.</param>
        public void SetActive(bool isActive, int pLevel, int levelIndex, bool isBossLevel, object levelFeatureInfoArgs = null)
        {
            base.SetActive(isActive);

            _leftLevelFeature.SetActive(false);
            _rightLevelFeature.SetActive(false);
            
            if (isActive)
            {
                _levelIndexTMP.Construct(levelIndex);
            }
            
            _leftPathLine.SetActive(false);
            _rightPathLine.SetActive(false);
            
            if (pLevel > levelIndex)
            {
                _topPathLine.SetActive(true, true);
                _bottomPathLine.SetActive(true, true);
            }
            else if (pLevel == levelIndex)
            {
                _topPathLine.SetActive(true, false);
                _bottomPathLine.SetActive(true, true);
                _levelNodeIMG.DoYoYo();
            }
            else
            {
                _topPathLine.SetActive(false, false);
                _bottomPathLine.SetActive(false, false);
            }

            if (levelIndex == pLevel + 1)
            {
                _bottomPathLine.SetActive(true, false);
            }
            
            if (levelIndex == 1)
            {
                _bottomPathLine.SetActive(false, false);
            }
        }
    }
}

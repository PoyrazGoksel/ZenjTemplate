using System.Collections.Generic;
using Components.Main.UI.LevelMap.MapNodes;
using Datas;
using Datas.Players;
using Events.External;
using Extensions.Unity;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using Zenject;

namespace Components.Main.UI.LevelMap
{
    public class LevelMapPanel : UIPanel
    {
        [Inject] private IPlayerData PlayerData { get; set; }
        [Inject] private PanelEvents PanelEvents { get; set; }
        [Inject] private UIEvents UIEvents { get; set; }
        [Inject] private IGameData GameData { get; set; }
        
        [SerializeField] private Transform _levelMapScrollContent;
        [SerializeField] private GameObject _levelMapNodePrefab;
        private List<LevelMapNodeUI> _currentNodes = new();
        private MonoPool _levelMapNodePool;

        private void Awake()
        {
            MonoPoolData monoPoolData = new(_levelMapNodePrefab, 10, _levelMapScrollContent);

            _levelMapNodePool = new MonoPool(monoPoolData);
        }

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            int nodesToInitFromIndex = PlayerData.CurrentLevel - 1;

            if (nodesToInitFromIndex < 0)
            {
                nodesToInitFromIndex = 0;
            }
            
            if (isActive)
            {
                for (int i = nodesToInitFromIndex; i < GameData.LevelCount; i ++)
                {
                    LevelMapNodeUI newNode = _levelMapNodePool.Request<LevelMapNodeUI>
                    (_levelMapScrollContent);

                    newNode.SetActive
                    (
                        true,
                        PlayerData.CurrentLevel,
                        i + 1,
                        false
                    );

                    _currentNodes.Add(newNode);
                }
            }
            else
            {
                foreach (LevelMapNodeUI levelMapNodeUI in _currentNodes)
                {
                    levelMapNodeUI.SetActive(false);
                }
            }
        }

        protected override void RegisterEvents()
        {
            base.RegisterEvents();
            PanelEvents.LevelMapPanelSetActive += OnLevelMapPanelSetActive;
            UIEvents.PlayButton += OnPlayButton;
        }

        private void OnPlayButton()
        {
            SetActive(false);
        }

        private void OnLevelMapPanelSetActive(bool arg0)
        {
            SetActive(arg0);
        }

        protected override void UnRegisterEvents()
        {
            base.UnRegisterEvents();
            PanelEvents.LevelMapPanelSetActive -= OnLevelMapPanelSetActive;
            UIEvents.PlayButton -= OnPlayButton;
        }
    }
}
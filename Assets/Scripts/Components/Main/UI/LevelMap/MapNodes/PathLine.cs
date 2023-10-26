using Extensions.Unity.MonoHelper;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Main.UI.LevelMap.MapNodes
{
    public class PathLine : UIIMG
    {
        private static readonly Color lineColor = new(0.1137255f, 0.172549f, 0.2705882f, 0.75f);
        private static readonly Color lineGlowColor = new(1f, 1f, 1f, 0.75f);
        
        [SerializeField] private Image _lineOutlineImage;

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);
            //_lineOutlineImage.enabled = isActive;
        }

        public void SetActive(bool isActive, bool isGlowing)
        {
            base.SetActive(isActive);
            
            if (isActive)
            {
                if (isGlowing)
                {
                    _myImg.color = lineGlowColor;
                    //_lineOutlineImage.enabled = true;
                }
                else
                {
                    _myImg.color = lineColor;
                    // _lineOutlineImage.enabled = false;
                }
            }
            else
            {
                // _lineOutlineImage.enabled = false;
            }
        }
    }
}
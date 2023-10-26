using Events.External;
using UnityEngine;
using Zenject;

namespace Components.Main.Example {
    public class GameCube : MonoBehaviour, IClickable
    {
        private static readonly int color = Shader.PropertyToID("_Color");
        
        [Inject] private ExampleEvents ExampleEvents { get; set; }
        [Inject] private GameStateEvents GameStateEvents { get; set; }
        
        [SerializeField] private MeshRenderer _meshRenderer;
        private MaterialPropertyBlock _materialPropertyBlock;

        private void Awake()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
            _meshRenderer.GetPropertyBlock(_materialPropertyBlock);
        }

        public void OnClick(int mouseButton)
        {
            switch (mouseButton)
            {
                case 0:
                    Debug.LogWarning("GameCube left clicked.");
                    GameStateEvents.LevelSuccess?.Invoke();
                    break;
                case 1:
                    Debug.LogWarning("GameCube right clicked.");
                    GameStateEvents.LevelFail?.Invoke();
                    break;
            }
        }

        private void OnMouseEnter()
        {
            _materialPropertyBlock.SetColor(color, Color.red);
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }

        private void OnMouseExit()
        {
            _materialPropertyBlock.SetColor(color, Color.white);
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }

    public interface IClickable
    {
        void OnClick(int mouseButton);
    }
}
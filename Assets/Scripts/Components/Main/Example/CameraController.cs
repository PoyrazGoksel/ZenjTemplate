using Events.External;
using UnityEngine;
using Zenject;

namespace Components.Main.Example
{
    public class CameraController : MonoBehaviour
    {
        [Inject] private ExampleEvents ExampleEvents { get; set; }
        [SerializeField] private Camera _myCamera;
        public Camera MainSceneCamera => _myCamera;
        
        private void Start()
        {
            Debug.LogWarning("CameraController started.");
            ExampleEvents.CameraControllerStart?.Invoke(this);
        }
    }
}

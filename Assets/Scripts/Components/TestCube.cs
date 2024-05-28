using Events;
using UnityEngine;
using Zenject;

namespace Components
{
    public class TestCube : MonoBehaviour
    {
        [Inject] private ProjectEvents ProjectEvents { get; set; }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnregisterEvents();
        }

        private void UnregisterEvents()
        {
            ProjectEvents.ProjectStarted -= OnProjectInstalled;
        }

        private void RegisterEvents()
        {
            ProjectEvents.ProjectStarted += OnProjectInstalled;
        }

        private void OnProjectInstalled()
        {
            Debug.LogWarning("VAR");
        }
    
    }
}

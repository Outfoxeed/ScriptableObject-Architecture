using UnityEngine;

namespace ScriptableObjectArchitecture.SceneReferences
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneReference[] _scenes;

        private void OnEnable()
        {
            foreach (SceneReference sceneReference in _scenes)
            {
                sceneReference.LoadAdditive();
            }
        }
    }
}
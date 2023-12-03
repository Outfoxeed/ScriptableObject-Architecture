using System;
using ScriptableObjectArchitecture.Base;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjectArchitecture.SceneReferences
{
    /// <summary>
    /// Scriptable in which is stored the name of a Scene.
    /// Has several public methods to load the registered scene
    /// </summary>
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.SceneReferencePath, order = 100)]
    public class SceneReference : ScriptableObjectArchitectureObject, ISceneReference
    {
        [SerializeField, Scene] private string _scene;
        
        public string Name => _scene;
        public IObservable<string> SceneLoaded => SceneLoadedCommand;

        private IReactiveCommand<string> SceneLoadedCommand => _sceneLoadedCommand ??= new ReactiveCommand<string>();
        private IReactiveCommand<string> _sceneLoadedCommand;
        
        public void Load() => Load(LoadSceneMode.Single);
        public void LoadAsync() => LoadAsync(LoadSceneMode.Single);

        public void LoadAdditive() => Load(LoadSceneMode.Additive);
        public void LoadAdditiveAsync() => LoadAsync(LoadSceneMode.Additive);

        private void Load(LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene(_scene, loadSceneMode);
            SceneLoadedCommand.Execute(_scene);
        }

        private void LoadAsync(LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadSceneAsync(_scene, loadSceneMode).completed += _ => SceneLoadedCommand.Execute(_scene);
        }
    }
}
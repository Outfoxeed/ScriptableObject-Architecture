using System;

namespace ScriptableObjectArchitecture.SceneReferences
{
    public interface ISceneReference
    {
        string Name {get;}
        void Load();
        void LoadAsync();
        void LoadAdditive();
        void LoadAdditiveAsync();

        IObservable<string> SceneLoaded { get; }
    }
}
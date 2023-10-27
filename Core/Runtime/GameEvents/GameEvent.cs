﻿using System;
using ScriptableObjectArchitecture.Utils;
using UniRx;

namespace ScriptableObjectArchitecture.GameEvents
{
    public abstract class GameEvent<T> : ReadOnlyGameEvent<T>, IGameEvent<T>
    {
        private ReactiveCommand<T> _reactiveCommand = new ReactiveCommand<T>();
        public override IDisposable Subscribe(IObserver<T> observer)
        {
            Logger.Instance?.Log($"'{this.name}' received a new subscription");
            return _reactiveCommand.Subscribe(observer);
        }

        public bool Raise(T parameter)
        {
            Logger.Instance?.Log($"'{this.name}' GameEvent raised with parameter '{parameter.ToString()}'");
            return _reactiveCommand.Execute(parameter);
        }

        public void Reset()
        {
            _reactiveCommand.Dispose();
            _reactiveCommand = new ReactiveCommand<T>();
        }

        public override string ToString()
        {
            return $"'{this.name}' game event";
        }
    }
}

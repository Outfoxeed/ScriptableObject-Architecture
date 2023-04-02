using System;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture.Subscriptions
{
    public class CompositeDisposable
    {
        private List<IDisposable> _disposables = new();
        public void Add(IDisposable disposable)
        {
            if (_disposables.Contains(disposable))
            {
                return;
            }
            _disposables.Add(disposable);
        }

        public void Dispose()
        {
            for (int i = _disposables.Count - 1; i >= 0; i--)
            {
                _disposables[i].Dispose();
                _disposables[i] = null;
                _disposables.Clear();
            }
        }
    }
}
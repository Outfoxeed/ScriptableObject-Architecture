﻿using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Game Event GameObject", menuName = "GameEvents/GameEvent (GameObject)", order = 1)]
    internal class GameObjectGameEvent : GameEvent<GameObject>
    {
    }
}

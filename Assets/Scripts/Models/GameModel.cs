using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameModel
{
    [HideInInspector] public UnityEvent OnLevelChange = new UnityEvent();
    public GameSettings Settings;

    private int _level;

    public int Level => _level;

    public void SetLevel(int level)
    {
        _level = level;
        OnLevelChange.Invoke();
    }
}
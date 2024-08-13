using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [SerializeField] private GameTab[] tabs;
    [SerializeField] private GameLevel[] levels;

    public GameTab GetTab(int index)
    {
        if (index < tabs.Length)
        {
            return tabs[index];
        }

        throw new IndexOutOfRangeException($"Error: no tab {index} by index, max is {tabs.Length - 1}");
    }

    public int GetTabsCount()
    {
        return tabs.Length;
    }

    public GameLevel GetLevel(int index)
    {
        if (index < levels.Length)
        {
            return levels[index];
        }

        throw new IndexOutOfRangeException($"Error: no level {index} by index, max is {levels.Length - 1}");
    }

    public int GetLevelCount()
    {
        return levels.Length;
    }
}

[Serializable]
public class GameTab
{
    public string name;
    public GameObject tabContent;
}


[Serializable]
public class GameLevel
{
    public string name;
    public Sprite levelSprite;
}
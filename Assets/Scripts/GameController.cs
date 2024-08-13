using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    
    public GameModel GameModel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new UnityException("Error: GameController is Singleton");
        }

        Application.targetFrameRate = 60;
    }
}
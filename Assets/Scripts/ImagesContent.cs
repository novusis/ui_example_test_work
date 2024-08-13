using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;

public class ImagesContent : MonoBehaviour
{
    [SerializeField] private SwitchImages imagesView;
    [SerializeField] private Button levelButton;
    private int _currentLevel = -1;
    private GameModel Game => GameController.Instance.GameModel;

    private void Start()
    {
        var levels = Game.Settings.GetLevelCount();
        for (int i = 0; i < levels; i++)
        {
            var button = levelButton;
            var index = i;

            if (i != 0)
            {
                button = Instantiate(levelButton, levelButton.transform.parent);
            }

            var levelConfig = Game.Settings.GetLevel(index);
            button.GetComponentInChildren<TextMeshProUGUI>().text = levelConfig.name;
            button.onClick.AddListener(() => Game.SetLevel(index));
        }

        Game.OnLevelChange.AddListener(DrawLevel);
        DrawLevel();
    }

    private void DrawLevel()
    {
        if (_currentLevel != Game.Level)
        {
            _currentLevel = Game.Level;
            var levelConfig = Game.Settings.GetLevel(_currentLevel);
            imagesView.SetImage(levelConfig.levelSprite);
        }
    }
}
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField] private Button tabButton;
    [SerializeField] private Transform tabContent;
    [SerializeField] private float _animationDuration = 0.4f;

    private GameSettings GameSettings => GameController.Instance.GameModel.Settings;
    private readonly Dictionary<string, GameObject> _tabs = new Dictionary<string, GameObject>();
    private readonly List<Button> _tabButtons = new List<Button>();
    private int _currentTab = -1;

    void Start()
    {
        var levels = GameSettings.GetTabsCount();
        for (int i = 0; i < levels; i++)
        {
            var button = tabButton;
            var index = i;

            if (i != 0)
            {
                button = Instantiate(tabButton, tabButton.transform.parent);
            }

            var tabConfig = GameSettings.GetTab(index);
            button.GetComponentInChildren<TextMeshProUGUI>().text = tabConfig.name;
            button.onClick.AddListener(() => TabSelected(index));
            _tabButtons.Add(button);
        }

        TabSelected(0);
    }

    private void TabSelected(int tabIndex)
    {
        if (tabIndex == _currentTab)
            return;

        _currentTab = tabIndex;
        var tabConfig = GameSettings.GetTab(tabIndex);
        if (!_tabs.ContainsKey(tabConfig.name))
        {
            var tab = Instantiate(tabConfig.tabContent, tabContent);
            var tabCanvasGroup = tab.GetComponent<CanvasGroup>();
            if (tabCanvasGroup)
            {
                tabCanvasGroup.alpha = 0f;
                tabCanvasGroup.DOFade(1, _animationDuration);
            }

            _tabs[tabConfig.name] = tab;
        }

        UpdateTabs();
    }

    private void UpdateTabs()
    {
        for (int i = 0; i < _tabs.Count; i++)
        {
            var tabConfig = GameSettings.GetTab(i);
            if (_tabs.TryGetValue(tabConfig.name, out var tab))
            {
                var showTab = i == _currentTab;
                var tabCanvasGroup = tab.GetComponent<CanvasGroup>();
                if (tabCanvasGroup)
                {
                    if (showTab)
                    {
                        tab.SetActive(true);
                        tabCanvasGroup.alpha = 0f;
                        tabCanvasGroup.DOKill();
                        tabCanvasGroup.DOFade(1, _animationDuration);
                    }
                    else if (tab.activeSelf)
                    {
                        tabCanvasGroup.DOKill();
                        tabCanvasGroup
                            .DOFade(0, _animationDuration)
                            .OnComplete(() => tab.SetActive(false));
                    }
                }
                else
                {
                    tab.SetActive(showTab);
                }
            }

            _tabButtons[i].interactable = i != _currentTab;
        }
    }
}
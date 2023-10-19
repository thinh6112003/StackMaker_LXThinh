using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextLevelButton;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        retryButton.onClick.AddListener(RetryButton);
        nextLevelButton.onClick.AddListener(NextLevelButton);
    }
    public void OnVictory()
    {
        victoryPanel.SetActive(true);
    }
    private void NextLevelButton()
    {
        victoryPanel.SetActive(false);
        LevelManager.Instance.NextLevel();
    }

    private void RetryButton()
    {
        victoryPanel.SetActive(false);
        LevelManager.Instance.retryLevel();
    }

    public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        levelPanel.SetActive(true);
        LevelManager.Instance.spawnLevel();
    }
    public void offLevelManager()
    {
        levelPanel.SetActive(false);
    }
}

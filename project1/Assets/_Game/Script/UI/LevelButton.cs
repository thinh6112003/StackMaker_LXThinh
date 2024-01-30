using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI textButton;
    public void SetData(int id)
    {
        textButton.text = $"level {id}";
        button.onClick.AddListener(() =>
        {
            LevelManager.Instance.playLevel(id);
            UIManager.Instance.offLevelManager();
        }
        );
    }
}

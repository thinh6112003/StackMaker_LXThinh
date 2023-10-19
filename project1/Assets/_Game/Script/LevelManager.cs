using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] ListLevelScriptableObject scriptableObject;
    [SerializeField] LevelButton buttonPrefab;
    [SerializeField] Transform buttonsParent;
    public int idLevel = 1;
    private void Start()
    {
    }

    public void NextLevel()
    {
        GameObject maplevel = GameObject.Find($"MapLevel{idLevel}(Clone)");
        Destroy(maplevel);
        idLevel++;
        GameObject levelPrefab = Resources.Load<GameObject>($"MapLevel{idLevel}");
        Instantiate(levelPrefab);
    }
    public void retryLevel()
    {

        GameObject maplevel = GameObject.Find($"MapLevel{idLevel}(Clone)");
        Destroy(maplevel);
        GameObject levelPrefab = Resources.Load<GameObject>($"MapLevel{idLevel}");
        Instantiate(levelPrefab);
    }
    public void spawnLevel()
    {
        foreach (LevelItem item in scriptableObject.listLevel)
        {
            LevelButton levelButton = Instantiate(buttonPrefab, buttonsParent);
            levelButton.name = $"Level {item.id}";
            levelButton.SetData(item.id);
            //GameObject levelPrefab = Resources.Load<GameObject>($"MapLevel{idLevel}");
            //Instantiate(levelPrefab);
        }
    }
    
    public void playLevel(int id)
    {
        idLevel = id;
        GameObject levelPrefab = Resources.Load<GameObject>($"MapLevel{id}");
        Instantiate(levelPrefab);
    }
}

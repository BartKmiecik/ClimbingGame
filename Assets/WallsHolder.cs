using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> wallsList = new List<GameObject>();
    private string currentLevel;
    int index;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetString("Level", "Wall3");
        LoadCurrentLevel();
    }

    private void LoadCurrentLevel()
    {
        Destroy(transform.GetChild(0).gameObject);
        for (int i = 0; i < wallsList.Count; i++)
        {
            if (currentLevel == wallsList[i].name)
            {
                index = i;
                currentLevel = wallsList[index].name;
                break;
            }
        }
        Instantiate(wallsList[index], transform);
    }
    public void LoadNextLevel()
    {
        Destroy(transform.GetChild(0).gameObject);
        ++index;
        Instantiate(wallsList[index], transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    private WallsHolder wallsHolder;
    void Start()
    {
        wallsHolder = FindObjectOfType<WallsHolder>();
    }

    public void LoadNextLvl()
    {
        if(wallsHolder == null)
        {
            wallsHolder = FindObjectOfType<WallsHolder>();
        }

        wallsHolder.LoadNextLevel();
    }
}

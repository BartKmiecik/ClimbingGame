using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDifficulty : MonoBehaviour
{
    [SerializeField] private float difficulty = .1f;
    public float Difficulty
    {
        get { return difficulty; }
    }
    
}

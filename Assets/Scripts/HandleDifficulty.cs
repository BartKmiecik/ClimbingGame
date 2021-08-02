using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDifficulty : MonoBehaviour
{
    [SerializeField] private float difficulty = .1f;
    [SerializeField] private ScriptableHandle scriptableHandle;
    public ScriptableHandle ScriptableHandle
    {
        get { return scriptableHandle; }
    }
    public float Difficulty
    {
        get { return difficulty; }
    }
    
}

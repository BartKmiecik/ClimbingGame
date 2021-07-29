using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObject/Handle")]
public class ScriptableHandle : ScriptableObject
{
    public GameObject uiModel;
    public GameObject prefabToInstantiate;
    public float difficultyLevel;
}

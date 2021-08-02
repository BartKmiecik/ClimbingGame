using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IconHandHolder : MonoBehaviour
{
    private ScriptableHandle handle;
    private TextMeshProUGUI difficultDisplay;
    private UIMapBuilder uiMapBuilder;
    public void Constructor(ScriptableHandle handle, TextMeshProUGUI text, UIMapBuilder uiMapBuilder)
    {
        this.uiMapBuilder = uiMapBuilder;
        this.difficultDisplay = text;
        this.handle = handle;
        Instantiate(handle.uiModel, gameObject.transform);
    }

    public void OnSelected()
    {
        difficultDisplay.text = "Difficulty level: " + handle.difficultyLevel;
        uiMapBuilder.SetHoleToSpawn(handle.prefabToInstantiate);
    }
}

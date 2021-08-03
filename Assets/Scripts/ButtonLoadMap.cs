using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonLoadMap : MonoBehaviour
{
    private BuildSceneSettingsPanel buildSceneSettingsPanel;
    [SerializeField] private TextMeshProUGUI text;

    public void Constructor(BuildSceneSettingsPanel buildSceneSettingsPanel, string text)
    {
        this.buildSceneSettingsPanel = buildSceneSettingsPanel;
        this.text.text = text;
    }

    public void LoadMap()
    {
        buildSceneSettingsPanel.LoadMap(text.text);
    }
}

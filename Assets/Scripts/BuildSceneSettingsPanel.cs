using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class BuildSceneSettingsPanel : MonoBehaviour
{
    private Vector3 startingPos;
    private string wallTitle;
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private TextMeshProUGUI placeHolder;
    [SerializeField] private PersistableSO persistableSO;
    [SerializeField] private Transform level;
    
    [SerializeField] private Transform customWallsMap;
    private Vector3 customWallsStartingPos;

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform spawningPoint;
    private void Start()
    {
        startingPos = transform.localPosition;
        customWallsStartingPos = customWallsMap.localPosition;
        LoadAllSavedMaps();
    }
    public void PopIn()
    {
        transform.DOLocalMove(Vector3.zero, 1, false);
    }

    public void PopOut()
    {
        transform.DOLocalMove(startingPos, 1, false);
    }

    public void Save()
    {
        if(inputField.text.Length > 1)
        {
            wallTitle = inputField.text;
            persistableSO.SaveNewLevel(wallTitle, level);
        } else
        {
            placeHolder.transform.DOShakeScale(.5f, .5f, 10, 90, false);
            placeHolder.faceColor = Color.red;
        }

        LoadAllSavedMaps();
    }

    public void Reset()
    {
        SceneManager.LoadScene("WallBuilding");
    }

    public void ShowSavedMaps()
    {
        customWallsMap.DOLocalMove(Vector3.zero, 1, false);
    }

    public void HideShowsMaps()
    {
        customWallsMap.DOLocalMove(customWallsStartingPos, 1, false);
    }

    public void LoadMap(string loadMap)
    {
        level.gameObject.GetComponent<Wall>().LoadLevel(loadMap);
        HideShowsMaps();
        PopOut();
    }

    public void LoadAllSavedMaps()
    {
        for(int i = 0; i < spawningPoint.childCount; i++)
        {
            Destroy(spawningPoint.GetChild(i).gameObject);
        }
        foreach (string str in persistableSO.wallsList.customWalls)
        {
            Instantiate(buttonPrefab, spawningPoint).GetComponent<ButtonLoadMap>().Constructor(this, str);
        }
    }
}

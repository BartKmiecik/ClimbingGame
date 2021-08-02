using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class BuildSceneSettingsPanel : MonoBehaviour
{
    private Vector3 startingPos;
    private string wallTitle;
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private TextMeshProUGUI placeHolder;
    [SerializeField] private PersistableSO persistableSO;
    [SerializeField] private Transform level;
    private void Start()
    {
        startingPos = transform.localPosition;
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
    }


}

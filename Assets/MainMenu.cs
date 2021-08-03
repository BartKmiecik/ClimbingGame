using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform customOrCamp, optionsPanel, campainPanel, customMapsPanel;
    private Vector3 customOrCampStartPos, optionsPanelPos;

    private void Start()
    {
        customOrCampStartPos = customOrCamp.localPosition;
        optionsPanelPos = optionsPanel.localPosition;
    }
    public void StartGame()
    {
        customOrCamp.DOLocalMove(Vector3.zero, 1, false);
        transform.DOLocalMove(customOrCampStartPos, 1, false);
    }

    public void HideCustomOrCamp()
    {
        customOrCamp.DOLocalMove(customOrCampStartPos, 1, false);
        transform.DOLocalMove(Vector3.zero, 1, false);
    }

    public void OpenCampainPanel()
    {
        customOrCamp.DOLocalMove(customOrCampStartPos, 1, false);
        campainPanel.DOLocalMove(Vector3.zero, 1, false);
    }

    public void HideCampainPanel()
    {
        customOrCamp.DOLocalMove(Vector3.zero, 1, false);
        campainPanel.DOLocalMove(customOrCampStartPos, 1, false);
    }

    public void OpenCustomMapsPanel()
    {
        customOrCamp.DOLocalMove(customOrCampStartPos, 1, false);
        customMapsPanel.DOLocalMove(Vector3.zero, 1, false);
    }

    public void HideCustomMapsPanel()
    {
        customOrCamp.DOLocalMove(Vector3.zero, 1, false);
        customMapsPanel.DOLocalMove(customOrCampStartPos, 1, false);
    }

    public void CreateCustomWall()
    {
        SceneManager.LoadScene("WallBuilding");
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.DOLocalMove(Vector3.zero, 1, false);
        transform.DOLocalMove(optionsPanelPos, 1, false);
    }

    public void CloseOptionsPanel()
    {
        optionsPanel.DOLocalMove(optionsPanelPos, 1, false);
        transform.DOLocalMove(Vector3.zero, 1, false);
    }


    public void CloseGame()
    {
        Application.Quit();
    }
}

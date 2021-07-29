using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class UIMapBuilder : MonoBehaviour
{
    enum state
    {
        inactive,
        building,
        modyfing
    }

    [SerializeField] private Transform builderPanel;
    [SerializeField] private List<ScriptableHandle> holesList = new List<ScriptableHandle>();
    [SerializeField] private Transform uiHolder;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private TextMeshProUGUI difficultText;
    [SerializeField] private Transform wall;
    private state buildingState;

    private GameObject holeToSpawn;

    private Vector3 startingPos;

    private int fingerID = -1;
    private void Awake()
    {
#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }
    private void Start()
    {
        buildingState = state.inactive;
        startingPos = builderPanel.localPosition;
        PopulateUIPanel();
    }
    public void ShowHidePanel(bool show)
    {
        if (show)
        {
            builderPanel.DOLocalMove(Vector3.zero, 1f, false);
        } else
        {
            builderPanel.DOLocalMove(startingPos, 1f, false);
        }
    }

    public void PopulateUIPanel()
    {
        foreach(ScriptableHandle handle in holesList)
        {
            Instantiate(iconPrefab, uiHolder).GetComponent<IconHandHolder>().Constructor(handle, difficultText, this);
        }
    }

    public void SetHoleToSpawn(GameObject hole)
    {
        this.holeToSpawn = hole;
    }

    public void StartBuilding()
    {
        ShowHidePanel(false);
        buildingState = state.building;
    }

    private void Update()
    {
        if (buildingState == state.building)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.collider.CompareTag("Wall") && EventSystem.current.IsPointerOverGameObject(-1) == false)
                    {
                        Instantiate(holeToSpawn, hit.point, Quaternion.identity).transform.SetParent(wall);
                    }
                }
            }
        }
    }
}

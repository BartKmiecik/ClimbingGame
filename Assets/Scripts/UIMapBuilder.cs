using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;

public class UIMapBuilder : MonoBehaviour
{
    enum UiBuildState
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
    [SerializeField] private Material holesMaterial;
    private UiBuildState buildingState;

    private ShowIndicators showIndicators;
    private HolesModyficator holesModyficator;

    private List<GameObject> handlersList = new List<GameObject>();

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
        holesModyficator = GetComponent<HolesModyficator>();
        showIndicators = GetComponent<ShowIndicators>();
        buildingState = UiBuildState.inactive;
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

    public void RemoveHole(GameObject hole)
    {
        handlersList.Remove(hole);
        ShowIndicators();
    }

    public void StartBuilding()
    {
        ShowHidePanel(false);
        HideIndicators();
        buildingState = UiBuildState.building;
    }

    private void Update()
    {
        if (buildingState == UiBuildState.building)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.collider.CompareTag("Wall") && EventSystem.current.IsPointerOverGameObject(fingerID) == false)
                    {
                        GameObject temp = Instantiate(holeToSpawn, hit.point, Quaternion.identity);
                        temp.GetComponent<ChangeMaterial>().ChangeMat(holesMaterial);
                        temp.transform.SetParent(wall);
                        handlersList.Add(temp);
                    }
                }
            }
        } else if(buildingState == UiBuildState.modyfing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.collider.CompareTag("Handlers"))
                    {
                        holesModyficator.ShowModyficationPanel(hit.collider.gameObject);
                        HideIndicators();
                    }
                }
            }
        }
    }

    public void ShowIndicators()
    {
        if(buildingState == UiBuildState.modyfing)
        {
            HideIndicators();
        } else
        {
            showIndicators.Show(handlersList);
            buildingState = UiBuildState.modyfing;
        }
    }

    public void HideIndicators()
    {
        showIndicators.Hide();
        buildingState = UiBuildState.inactive;
    }

    public void ChangeHolesColor(Color color)
    {
        holesMaterial.color = color;
    }
}

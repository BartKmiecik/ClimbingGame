using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HolesModyficator : MonoBehaviour
{
    enum ModyficationState
    {
        nothing,
        move,
        scale,
    }

    [SerializeField] private Transform modyficationPanel;
    private GameObject holeToModyfication;
    private Vector3 startingPos;
    private ModyficationState state;

    private UIMapBuilder uiMapBuilder;

    private int fingerID = -1;
    private void Awake()
    {
#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }

    private void Start()
    {
        uiMapBuilder = GetComponent<UIMapBuilder>();
        startingPos = modyficationPanel.localPosition;
    }
    public void ShowModyficationPanel(GameObject obj)
    {
        state = ModyficationState.nothing;
        holeToModyfication = obj;
        modyficationPanel.DOLocalMove(Vector3.zero, 1f, false);
    }

    public void HideModyficationPanel()
    {
        state = ModyficationState.nothing;
        holeToModyfication = null;
        modyficationPanel.DOLocalMove(startingPos, 1f, false);
    }

    public void RemoveHole()
    {
        state = ModyficationState.nothing;
        uiMapBuilder.RemoveHole(holeToModyfication);
        Destroy(holeToModyfication);
        HideModyficationPanel();
    }

    public void Move()
    {
        state = ModyficationState.move;
    }

    private void Update()
    {
        if(state == ModyficationState.move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.collider.CompareTag("Wall") && EventSystem.current.IsPointerOverGameObject(fingerID) == false)
                    {
                        holeToModyfication.transform.position = hit.point;
                    }
                }
            }
        }
    }
}

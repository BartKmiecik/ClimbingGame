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
        rotate
    }

    [SerializeField] private Transform modyficationPanel;
    private GameObject holeToModyfication;
    private Vector3 startingPos;
    private ModyficationState state;

    private UIMapBuilder uiMapBuilder;

    private Camera cam;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float scaleSpeed = 100f;

    private int fingerID = -1;
    private void Awake()
    {
#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }

    private void Start()
    {
        cam = Camera.main;
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

    public void Rotate()
    {
        state = ModyficationState.rotate;
    }

    public void Scale()
    {
        state = ModyficationState.scale;
    }

    private void Update()
    {
        if(state == ModyficationState.move)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.collider.CompareTag("Wall") && EventSystem.current.IsPointerOverGameObject(fingerID) == false)
                    {
                        holeToModyfication.transform.position = hit.point;
                    }
                }
            }
        } 
        if(state == ModyficationState.rotate)
        {
            if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject(fingerID) == false)
            {
                holeToModyfication.transform.Rotate(0,0, (Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), Space.World);
            }
        }
        if(state == ModyficationState.scale)
        {
            if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject(fingerID) == false)
            {
                Vector3 curremtScale = holeToModyfication.transform.localScale;
                Vector3 newScale = new Vector3(Mathf.Clamp(curremtScale.x + (Input.GetAxis("Mouse X") * scaleSpeed * Time.deltaTime), 5f, 100),
                    Mathf.Clamp(curremtScale.y + (Input.GetAxis("Mouse Y") * scaleSpeed * Time.deltaTime), 5, 100), curremtScale.z);

                holeToModyfication.transform.localScale = newScale;

            }
        }

    }
}

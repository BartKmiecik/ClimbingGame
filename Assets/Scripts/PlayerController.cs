using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform eyeysTargeting;
    private bool eyesStartTracking;

    private JointsRotation jointRotation;

    private CameraPoint cameraPoint;

    [SerializeField] private LayerMask layerToIgnore;
    private Camera cam;
    private Transform objectToMove;
    private bool isDragging;
    private Vector3 screenPoint;
    private Vector3 offset;
    void Start()
    {
        cameraPoint = GetComponent<CameraPoint>();
        isDragging = false;
        cam = Camera.main;
        cameraPoint.MoveToMiddlePoint();
        jointRotation = GetComponent<JointsRotation>();
        jointRotation.RotateJoints();
        eyesStartTracking = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, ~layerToIgnore))
            {
                if (hit.collider.CompareTag("Movable"))
                {
                    objectToMove = hit.transform;
                    isDragging = true;
                    screenPoint = cam.WorldToScreenPoint(gameObject.transform.position);

                    offset = objectToMove.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, .3f));

                    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, .3f);

                    Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;

                    eyeysTargeting.DOMove(curPosition, .3f).OnComplete(() => { eyesStartTracking = true; });
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, .3f);

            Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
            objectToMove.position = curPosition;
            
            jointRotation.RotateJoints();

            if (eyesStartTracking)
            {
                eyeysTargeting.position = curPosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            objectToMove = null;
            isDragging = false;
            cameraPoint.MoveToMiddlePoint();
            eyesStartTracking = false;
        }

    }


}

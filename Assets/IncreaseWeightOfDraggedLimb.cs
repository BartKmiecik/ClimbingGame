using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeightOfDraggedLimb : MonoBehaviour
{
    [SerializeField] private SegmentsManager.LimbPosition position;
    private LimbsCollisionChecker limbsCollisionChecker;

    private void Start()
    {
        limbsCollisionChecker = FindObjectOfType<LimbsCollisionChecker>();
    }
    public void Increase()
    {
        limbsCollisionChecker.ChangeDraggedLimb(position);
    }

    public void Decrease()
    {
        limbsCollisionChecker.ChangeDraggedLimb(SegmentsManager.LimbPosition.inactive);
    }

    private void OnMouseDown()
    {
        Increase();
    }

    private void OnMouseUp()
    {
        Decrease();
    }
}

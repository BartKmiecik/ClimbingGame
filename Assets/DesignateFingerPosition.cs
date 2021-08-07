using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignateFingerPosition : MonoBehaviour
{
    private BioIK.Projection projection;
    
    private void Start()
    {
        projection = GetComponent<BioIK.Projection>();
        projection.SetTargetPosition(transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Handlers"))
        {
            projection.SetTargetPosition(other.ClosestPoint(transform.position));
        }

    }

    
}

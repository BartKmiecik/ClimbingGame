using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFromWall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BioIK.BioIK bioIK;

    public void Fall()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        bioIK.enabled = false;
    }
}

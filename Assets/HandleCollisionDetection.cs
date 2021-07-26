using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisionDetection : MonoBehaviour
{
    private LimbsCollisionChecker limbsCollisionChecker;
    [SerializeField] private LimbsCollisionChecker.Limb limb;

    private bool isColliding;
    public bool IsColliding
    {
        get { return isColliding; }
    }


    private void Start()
    {
        limbsCollisionChecker = FindObjectOfType<LimbsCollisionChecker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        limbsCollisionChecker.SetCollision(limb, isColliding);
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        limbsCollisionChecker.SetCollision(limb, isColliding);
    }
}

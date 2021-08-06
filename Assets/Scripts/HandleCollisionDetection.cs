using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisionDetection : MonoBehaviour
{
    private LimbsCollisionChecker limbsCollisionChecker;
    [SerializeField] private LimbsCollisionChecker.Limb limb;
    private float difficulty = 0;
    public float Difficulty
    {
        get { return difficulty; }
    }

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
        if (other.CompareTag("Handlers"))
        {
            isColliding = true;
            difficulty = other.GetComponent<HandleDifficulty>().Difficulty;
            limbsCollisionChecker.SetCollision(limb, isColliding, difficulty);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Handlers"))
        {
            isColliding = false;
            difficulty = 0;
            limbsCollisionChecker.SetCollision(limb, isColliding, difficulty);
        }

    }
}

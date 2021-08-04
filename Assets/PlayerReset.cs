using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField] private Transform leftHand, rightHand, leftLeg, rightLeg, body;
    private Vector3 leftHStart, rightHStart, leftLStart, rightLStart, bodyStart;
    private LimbsCollisionChecker collisionChecker;
    private ExtraChecking extraChecking;
    private TirednessSystem tirednessSystem;
    private ShowWarrining showWarrning;
    private void Start()
    {
        tirednessSystem = GetComponent<TirednessSystem>();
        collisionChecker = GetComponent<LimbsCollisionChecker>();
        extraChecking = GetComponent<ExtraChecking>();

        StartCoroutine(DeleyChecking());
    }

    public void SetStartingPosition()
    {
        leftLStart = leftLeg.position;
        rightLStart = rightLeg.position;
        leftHStart = leftHand.position;
        rightHStart = rightHand.position;
        bodyStart = body.position;
    }
    public void ResetPosition()
    {
        leftHand.position = leftHStart;
        rightHand.position = rightHStart;
        leftLeg.position = leftLStart;
        rightLeg.position = rightLStart;
        //body.position = bodyStart;
        tirednessSystem.ResetTirednes();
        showWarrning.ShowText(false);
    }

    IEnumerator DeleyChecking()
    {
        yield return new WaitForSeconds(1f);
        extraChecking.enabled = true;
        collisionChecker.enabled = true;

    }
}

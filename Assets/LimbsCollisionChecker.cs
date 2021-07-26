using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsCollisionChecker : MonoBehaviour
{
    private bool leftFoot, rightFoot, leftHand, rightHand;

    public void SetCollision(Limb limb, bool colliding)
    {
        switch (limb)
        {
            case Limb.leftFoot:
                leftFoot = colliding;
                break;
            case Limb.rightFoot:
                rightFoot = colliding;
                break;
            case Limb.leftHand:
                leftHand = colliding;
                break;
            case Limb.rightHand:
                rightHand = colliding;
                break;
            default:
                break;
        }
    }
    public enum Limb
    {
        leftHand,
        rightHand,
        leftFoot,
        rightFoot
    }
}

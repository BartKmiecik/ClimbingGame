using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsCollisionChecker : MonoBehaviour
{
    public bool leftFoot, rightFoot, leftHand, rightHand;
    public float lFootDiff, rFootDiff, lHandDiff, rHandDiff;
    private int limbsTouching;
    public int LimbsTouching
    {
        get { return limbsTouching; }
    }
    public void SetCollision(Limb limb, bool colliding, float diff)
    {
        switch (limb)
        {
            case Limb.leftFoot:
                leftFoot = colliding;
                lFootDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                }
                else --limbsTouching;
                break;
            case Limb.rightFoot:
                rightFoot = colliding;
                rFootDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                }
                else --limbsTouching;
                break;
            case Limb.leftHand:
                leftHand = colliding;
                lHandDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                }
                else --limbsTouching;
                break;
            case Limb.rightHand:
                rightHand = colliding;
                rHandDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                }
                else --limbsTouching;
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

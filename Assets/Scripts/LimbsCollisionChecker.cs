using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsCollisionChecker : MonoBehaviour
{
    private FallFromWall fall;

    public bool leftFoot, rightFoot, leftHand, rightHand;
    public float lFootDiff, rFootDiff, lHandDiff, rHandDiff;
    private int limbsTouching;
    [SerializeField] private Material lLIndicator, rLIndicator, lHIndicator, rHIndicator;

    [SerializeField] private Color collidingColor, notColliding;

    private void Start()
    {
        fall = GetComponent<FallFromWall>();
        leftFoot = rightFoot = leftHand = rightHand = true;
    }
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
                    lLIndicator.color = collidingColor;
                }
                else { 
                    --limbsTouching;
                    lLIndicator.color = notColliding;
                }
                
                break;
            case Limb.rightFoot:
                rightFoot = colliding;
                rFootDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                    rLIndicator.color = collidingColor;
                }
                else
                {
                    --limbsTouching;
                    rLIndicator.color = notColliding;
                }
                break;
            case Limb.leftHand:
                leftHand = colliding;
                lHandDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                    lHIndicator.color = collidingColor;
                }
                else
                {
                    --limbsTouching;
                    lHIndicator.color = notColliding;
                }
                break;
            case Limb.rightHand:
                rightHand = colliding;
                rHandDiff = diff;
                if (colliding)
                {
                    ++limbsTouching;
                    rHIndicator.color = collidingColor;
                }
                else
                {
                    --limbsTouching;
                    rHIndicator.color = notColliding;
                }
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

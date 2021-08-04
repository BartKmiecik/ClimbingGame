using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsCollisionChecker : MonoBehaviour
{
    private float sumWeight = 200f;
    private FallFromWall fall;

    public bool leftFoot, rightFoot, leftHand, rightHand;
    public float lFootDiff, rFootDiff, lHandDiff, rHandDiff;
    private int limbsTouching;
    [SerializeField] private Material lLIndicator, rLIndicator, lHIndicator, rHIndicator;

    [SerializeField] private Color collidingColor, notColliding;

    [SerializeField] private SegmentsManager segmentsManager;

    private PlayerReset playerReset;

    private void Start()
    {
        fall = GetComponent<FallFromWall>();
        leftFoot = rightFoot = leftHand = rightHand = true;
        playerReset = GetComponent<PlayerReset>();
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

        if(limbsTouching > 3)
        {
            playerReset.SetStartingPosition();
        }

        AdjustLimbsWeight();
    }
    public enum Limb
    {
        leftHand,
        rightHand,
        leftFoot,
        rightFoot
    }    

    private void AdjustLimbsWeight()
    {
        float weight = sumWeight / limbsTouching;

        segmentsManager.ChangeWeightAll(weight);
        if (!leftFoot)
        {
            segmentsManager.SetSingleWeight(SegmentsManager.LimbPosition.leftLeg, 10);
        }
        if (!rightFoot)
        {
            segmentsManager.SetSingleWeight(SegmentsManager.LimbPosition.rightLeg, 10);
        }
        if (!leftHand)
        {
            segmentsManager.SetSingleWeight(SegmentsManager.LimbPosition.leftHand, 10);
        }
        if (!rightHand)
        {
            segmentsManager.SetSingleWeight(SegmentsManager.LimbPosition.rightHand, 10);
        }
    }
}

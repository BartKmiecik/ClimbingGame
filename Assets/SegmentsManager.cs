using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BioIK;
public class SegmentsManager : MonoBehaviour
{
    public Position leftLeg, rightLeg, leftHand, rightHand;

    public void ChangeWeightAll(float weight)
    {
        leftLeg.SetWeight(weight);
        rightLeg.SetWeight(weight);
        leftHand.SetWeight(weight);
        rightHand.SetWeight(weight);
    }

    public void SetSingleWeight(LimbPosition position, float weight)
    {
        switch (position)
        {
            case LimbPosition.leftLeg:
                leftLeg.SetWeight(weight);
                break;
            case LimbPosition.rightLeg:
                rightLeg.SetWeight(weight);
                break;
            case LimbPosition.leftHand:
                leftHand.SetWeight(weight);
                break;
            case LimbPosition.rightHand:
                rightHand.SetWeight(weight);
                break;
        }
    }

    public enum LimbPosition
    {
        leftLeg,
        rightLeg,
        leftHand,
        rightHand
    }
}

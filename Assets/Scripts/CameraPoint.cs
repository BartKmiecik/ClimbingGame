using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraPoint : MonoBehaviour
{
    [SerializeField] private Transform leftLeg, rightLeg, leftHand, rightHand;

    public void MoveToMiddlePoint()
    {
        Vector3 center  = (leftLeg.position + rightLeg.position + leftHand.position + rightHand.position) / 4;
        transform.DOMove(center, 1f, false);
    }
}

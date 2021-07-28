using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointsRotation : MonoBehaviour
{
    [SerializeField] private Transform leftFoot, rightFoot, middlePoint;
    private float diffX, diffY;
    public void RotateJoints()
    {
        diffX = Mathf.Clamp(((float)rightFoot.position.x - (float)middlePoint.position.x)* 90, - 40, 90);
        diffY = Mathf.Clamp(((float)rightFoot.position.y - (float)middlePoint.position.y + 1f) * -20, -60, 25);
        rightFoot.localRotation = Quaternion.Euler(0, 90 + diffX, -180 + diffY);

        diffX = Mathf.Clamp(((float)leftFoot.position.x - (float)middlePoint.position.x) * 90, -90, 40);
        diffY = Mathf.Clamp(((float)leftFoot.position.y - (float)middlePoint.position.y + 1f) * -20, -60, 25);
        leftFoot.localRotation = Quaternion.Euler(diffY, diffX, 0);
    }
}

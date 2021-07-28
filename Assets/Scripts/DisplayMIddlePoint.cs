using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMIddlePoint : MonoBehaviour
{
    [SerializeField] private Transform p1, p2, p3, p4;
    [SerializeField] private LimbsCollisionChecker limbsCollisionChecker;
    private void OnDrawGizmos()
    {
        float x1 = (p1.position.x + p2.position.x) / 2;
        float y1 = (p1.position.y + p2.position.y) / 2;
        float z1 = (p1.position.z + p2.position.z) / 2;

        float x2 = (p3.position.x + p4.position.x) / 2;
        float y2 = (p3.position.y + p4.position.y) / 2;
        float z2 = (p3.position.z + p4.position.z) / 2;

        float finalX = (x1 + x2) / 2;
        float finalY = (y1 + y2) / 2;
        float finalZ = (z1 + z2) / 2;

        Vector3 final = new Vector3(finalX, finalY, finalZ);

        Gizmos.color = Color.red;

        Gizmos.DrawSphere(final, .05f);


        Gizmos.color = Color.green;

        float angler = 0;

        if (limbsCollisionChecker.leftFoot && limbsCollisionChecker.rightFoot)
        {
            Vector3 temp = new Vector3(x2, y2, z2);
            Gizmos.DrawLine(temp, temp + new Vector3(1f, .6f, 0));
            Gizmos.DrawLine(temp, temp + new Vector3(-1f, .6f, 0));
            angler = Mathf.Atan2(y2 - finalY, x2 - finalX) * 180 / Mathf.PI;
        }
        else if (limbsCollisionChecker.rightFoot && limbsCollisionChecker.rightHand)
        {
            Vector3 temp = new Vector3((p1.position.x + p3.position.x) / 2, (p1.position.y + p3.position.y) / 2, (p1.position.z + p3.position.z) / 2);
            Gizmos.DrawLine(temp, temp + new Vector3(-1.78f, 1f, 0));
            Gizmos.DrawLine(temp, temp + new Vector3(-1.78f, -1f, 0));
            angler = Mathf.Atan2(temp.y - finalY, temp.x - finalX) * 180 / Mathf.PI;
        }
        else if (limbsCollisionChecker.rightFoot)
        {
            Gizmos.DrawLine(p3.position, p3.position + new Vector3(1f, 3.8f, 0));
            Gizmos.DrawLine(p3.position, p3.position + new Vector3(-1f, 3.8f, 0));
            angler = Mathf.Atan2(p3.position.y - finalY, p3.position.x - finalX) * 180 / Mathf.PI;
        }
        else if (limbsCollisionChecker.leftFoot && limbsCollisionChecker.leftHand)
        {
            Vector3 temp = new Vector3((p2.position.x + p4.position.x) / 2, (p2.position.y + p4.position.y) / 2, (p2.position.z + p4.position.z) / 2);
            Gizmos.DrawLine(temp, temp + new Vector3(1.78f, 1f, 0));
            Gizmos.DrawLine(temp, temp + new Vector3(1.78f, -1f, 0));
            angler = Mathf.Atan2(temp.y - finalY, temp.x - finalX) * 180 / Mathf.PI;
        }
        else if (limbsCollisionChecker.leftFoot)
        {
            Gizmos.DrawLine(p4.position, p4.position + new Vector3(1f, 3.8f, 0));
            Gizmos.DrawLine(p4.position, p4.position + new Vector3(-1f, 3.8f, 0));
            angler = Mathf.Atan2(p4.position.y - finalY, p4.position.x - finalX) * 180 / Mathf.PI;
        } 



        Gizmos.color = Color.blue;
        if(limbsCollisionChecker.rightHand && limbsCollisionChecker.leftHand)
        {
            Vector3 temp = new Vector3(x1, y1, z1);
            Gizmos.DrawLine(temp, temp + new Vector3(1f, -.6f, 0));
            Gizmos.DrawLine(temp, temp + new Vector3(-1f, -.6f, 0));
        } else if (limbsCollisionChecker.rightHand)
        {
            Gizmos.DrawLine(p1.position, p1.position + new Vector3(1f, -1.78f, 0));
            Gizmos.DrawLine(p1.position, p1.position + new Vector3(-1f, -1.78f, 0));
        } else if (limbsCollisionChecker.leftHand)
        {
            Gizmos.DrawLine(p2.position, p2.position + new Vector3(1f, -1.78f, 0));
            Gizmos.DrawLine(p2.position, p2.position + new Vector3(-1f, -1.78f, 0));
        }

         

        Debug.Log("Leg angle: " + angler);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMIddlePoint : MonoBehaviour
{
    [SerializeField] private Transform p1, p2, p3, p4;
    private void OnDrawGizmos()
    {
        float x1 = (p1.position.x + p3.position.x) / 2;
        float y1 = (p1.position.y + p3.position.y) / 2;
        float z1 = (p1.position.z + p3.position.z) / 2;

        float x2 = (p2.position.x + p4.position.x) / 2;
        float y2 = (p2.position.y + p4.position.y) / 2;
        float z2 = (p2.position.z + p4.position.z) / 2;

        float finalX = (x1 + x2)/ 2;
        float finalY = (y1 + y2) / 2;
        float finalZ = (z1 + z2) / 2;

        Vector3 final = new Vector3(finalX, finalY, finalZ);

        Gizmos.color = Color.red;

        Gizmos.DrawSphere(final, .2f);

        Gizmos.color = Color.green;

        Gizmos.DrawLine(p4.position, p4.position + new Vector3(1f, 3.81f,0));
        Gizmos.DrawLine(p4.position, p4.position + new Vector3(-1f, 3.81f, 0));
    }
}

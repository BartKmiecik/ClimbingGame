using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FallFromWall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BioIK.BioIK bioIK;

    public void Fall()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        bioIK.enabled = false;
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}

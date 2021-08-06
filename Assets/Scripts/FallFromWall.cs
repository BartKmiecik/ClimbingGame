using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class FallFromWall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BioIK.BioIK bioIK;
    private PlayerReset playerReset;

    [SerializeField] private GameObject onFallPanel;
    private Vector3 fallPanelStartingPos;

    private LimbsCollisionChecker limbsCollisionChecker;
    private ExtraChecking extraChecking;
    private void Start()
    {
        fallPanelStartingPos = onFallPanel.transform.localPosition;
        extraChecking = GetComponent<ExtraChecking>();
        limbsCollisionChecker = GetComponent<LimbsCollisionChecker>();
        onFallPanel.SetActive(false);
        playerReset = GetComponent<PlayerReset>();
    }
    public void Fall()
    {
        Debug.Log("Fall");
        extraChecking.enabled = false;
        limbsCollisionChecker.enabled = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        bioIK.enabled = false;
        StartCoroutine(DeeleyFallingPanel());
    }

    public void ResetartLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Continue()
    {
        onFallPanel.transform.DOLocalMove(fallPanelStartingPos, 1, false).OnComplete(() => onFallPanel.SetActive(false));
        playerReset.ResetPosition();
        rb.isKinematic = true;
        rb.useGravity = false;
        bioIK.enabled = true;
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator DeeleyFallingPanel()
    {
        yield return new WaitForSeconds(1f);
        onFallPanel.SetActive(true);
        onFallPanel.transform.DOLocalMove(Vector3.zero, 1, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class StartCountingToWin : MonoBehaviour
{
    private int hands;
    private float counter = 3f;
    [SerializeField] private TextMeshProUGUI countingText;
    [SerializeField] private Transform countingTextTransform;

    [SerializeField] private GameObject winningPanel;
    private Vector3 winningPanelStartingPos;
    private void Start()
    {
        winningPanelStartingPos = winningPanel.transform.localPosition;
        hands = 0;
        countingTextTransform.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            ++hands;
        }
        if(hands == 2)
        {
            StartCoroutine(StartCounting());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            --hands;
        }
        StopAllCoroutines();
        countingTextTransform.gameObject.SetActive(false);
        counter = 3f;
    }

    IEnumerator StartCounting()
    {
        countingTextTransform.gameObject.SetActive(true);
        countingTextTransform.DOScale(0.5f, 1).From(1f).SetLoops(3);
        while(counter > 0)
        {
            yield return null;
            counter -= Time.deltaTime;
            if(counter < 0)
            {
                counter = 0;
                countingText.text = "You win!";
                //Popup panel that indicate how much your strenght increase and allow player to decide what to do next (next wall, or go back to menu)
                //Right now just focus on simple panel next game / back to menu
            } else
            {
                countingText.text = counter.ToString("F1");
            }
        }

        Debug.Log("Win");

        ShowWinningPanel(true);
    }

    public void ShowWinningPanel(bool show)
    {
        if (show)
        {
            winningPanel.transform.DOLocalMove(Vector3.zero, 1, false);
        } else
        {
            winningPanel.transform.DOLocalMove(winningPanelStartingPos, 1, false);
        }
    }
}

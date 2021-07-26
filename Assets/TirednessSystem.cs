using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TirednessSystem : MonoBehaviour
{
    private LimbsCollisionChecker limbsCollisionChecker;
    private float leftFootStrenght, rightFootStrenght, leftHandStrenght, rightHandStrenght;
    [SerializeField] private Image lFI, rFI, lHI, rHI;
    void Start()
    {
        limbsCollisionChecker = GetComponent<LimbsCollisionChecker>();
        leftFootStrenght = rightFootStrenght = leftHandStrenght = rightHandStrenght = 2;
    }

    void Update()
    {
        int limbsTouching = limbsCollisionChecker.LimbsTouching;
        if (limbsCollisionChecker.leftFoot)
        {
            leftFootStrenght -= (limbsCollisionChecker.lFootDiff / limbsTouching) * Time.deltaTime;
            if(leftFootStrenght < limbsCollisionChecker.lFootDiff)
            {
                Debug.Log("Not enough strnght left leg");
            }
        }

        if (limbsCollisionChecker.rightFoot)
        {
            rightFootStrenght -= (limbsCollisionChecker.rFootDiff / limbsTouching) * Time.deltaTime;
            if (rightFootStrenght < limbsCollisionChecker.rFootDiff)
            {
                Debug.Log("Not enough strnght right leg");
            }
        }

        if (limbsCollisionChecker.leftHand)
        {
            leftHandStrenght -= (limbsCollisionChecker.lHandDiff / limbsTouching) * Time.deltaTime;
            if (leftHandStrenght < limbsCollisionChecker.lHandDiff)
            {
                Debug.Log("Not enough strnght");
            }
        }

        if (limbsCollisionChecker.rightHand)
        {
            rightHandStrenght -= (limbsCollisionChecker.rHandDiff / limbsTouching) * Time.deltaTime;
            if (rightHandStrenght < limbsCollisionChecker.rHandDiff)
            {
                Debug.Log("Not enough strnght");
            }
        }

        lFI.fillAmount = leftFootStrenght;
        rFI.fillAmount = rightFootStrenght;
        lHI.fillAmount = leftHandStrenght;
        rHI.fillAmount = rightHandStrenght;
    }
}

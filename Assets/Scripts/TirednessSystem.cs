using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TirednessSystem : MonoBehaviour
{
    private LimbsCollisionChecker limbsCollisionChecker;
    private float leftFootStrenght, rightFootStrenght, leftHandStrenght, rightHandStrenght;
    private float currentLeftFootStr, currentRightFootStr, currentLeftHandStr, currentRightHandStr;
    [SerializeField] private Image lFI, rFI, lHI, rHI;
    [SerializeField] private float strenght;
    void Awake()
    {
        limbsCollisionChecker = GetComponent<LimbsCollisionChecker>();
        ResetTirednes();
    }

    public void ResetTirednes()
    {
        leftFootStrenght = rightFootStrenght = leftHandStrenght = rightHandStrenght = strenght;
        currentLeftFootStr = currentRightFootStr = currentLeftHandStr = currentRightHandStr = strenght;
    }

    void Update()
    {
        int limbsTouching = limbsCollisionChecker.LimbsTouching;

        if(limbsTouching > 0)
        {
            if (limbsCollisionChecker.leftFoot)
            {
                currentLeftFootStr -= (limbsCollisionChecker.lFootDiff / limbsTouching) * Time.deltaTime;
                if (currentLeftFootStr < limbsCollisionChecker.lFootDiff)
                {
                    Debug.Log("Not enough strnght left leg");
                }
            }

            if (limbsCollisionChecker.rightFoot)
            {
                currentRightFootStr -= (limbsCollisionChecker.rFootDiff / limbsTouching) * Time.deltaTime;
                if (currentRightFootStr < limbsCollisionChecker.rFootDiff)
                {
                    Debug.Log("Not enough strnght right leg");
                }
            }

            if (limbsCollisionChecker.leftHand)
            {
                currentLeftHandStr -= (limbsCollisionChecker.lHandDiff / limbsTouching) * Time.deltaTime;
                if (currentLeftHandStr < limbsCollisionChecker.lHandDiff)
                {
                    Debug.Log("Not enough strnght");
                }
            }

            if (limbsCollisionChecker.rightHand)
            {
                currentRightHandStr -= (limbsCollisionChecker.rHandDiff / limbsTouching) * Time.deltaTime;
                if (currentRightHandStr < limbsCollisionChecker.rHandDiff)
                {
                    Debug.Log("Not enough strnght");
                }
            }


            lFI.fillAmount = currentLeftFootStr / leftFootStrenght;
            rFI.fillAmount = currentRightFootStr / rightFootStrenght;
            lHI.fillAmount = currentLeftHandStr / leftHandStrenght;
            rHI.fillAmount = currentRightHandStr / rightHandStrenght;

        }
    }
}

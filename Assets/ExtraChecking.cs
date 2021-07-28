using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In case if only 2 or 1 limbs touching handlers, count weight middle point and designate angles to check if player should fall. If only 2 legs touching handlers you can move body weight in 90 degree 
// vertical radius from point between foots, when only hand and leg from same side(left or right) touching handler you have 60degre horizontal, in case of only 1 leg or hand 15 degree;
public class ExtraChecking : MonoBehaviour
{
    [SerializeField] private float singleLimb, twoSameLimbs, twoSameSideLimbs;
    [SerializeField] private Transform leftLeg, rightLeg, leftArm, rightArm;
    [SerializeField] private LimbsCollisionChecker limbsCollisionChecker;
    [SerializeField] private FallFromWall fall;
    private bool isGameStarted;

    //Warrining sign offest
    private float showWarningDegree = 10f;
    private ShowWarrining showWarrining;

    //Extra offset when hand and leg touching handlers, but it slighty away from first check
    private float extraOffset = 5;

    //Reduce amount of calculation, only every 3rd LateUpdate
    int deleay = 0;

    private void Start()
    {
        StartCoroutine(DeleyChecking());
        showWarrining = GetComponent<ShowWarrining>();
    }
    private void LateUpdate()
    {
        if(deleay < 3)
        {
            ++deleay;
        } else
        {
            deleay = 0;
            if(limbsCollisionChecker.LimbsTouching < 4 && limbsCollisionChecker.LimbsTouching > 0)
            {
                if(limbsCollisionChecker.LimbsTouching == 3)
                {
                    showWarrining.ShowText(false);
                    return;
                }
                //Legs
                float x1 = (leftLeg.position.x + rightLeg.position.x) / 2;
                float y1 = (leftLeg.position.y + rightLeg.position.y) / 2;
                float z1 = (leftLeg.position.z + rightLeg.position.z) / 2;
                //Hands
                float x2 = (leftArm.position.x + rightArm.position.x) / 2;
                float y2 = (leftArm.position.y + rightArm.position.y) / 2;
                float z2 = (leftArm.position.z + rightArm.position.z) / 2;
                //MIddle
                float finalX = (x1 + x2) / 2;
                float finalY = (y1 + y2) / 2;
                float finalZ = (z1 + z2) / 2;

                //// Calculate legs

                if (limbsCollisionChecker.leftFoot && limbsCollisionChecker.rightFoot)
                {
                    float angle = Mathf.Atan2(finalY - y1, finalX - x1) * 180 / Mathf.PI - 90;
                    if (angle <= -(twoSameLimbs - showWarningDegree) || angle >= (twoSameLimbs - showWarningDegree))
                    {
                        showWarrining.ShowText(true);
                    } else showWarrining.ShowText(false);
                    if (angle <= -twoSameLimbs || angle >= twoSameLimbs)
                    {
                        fall.Fall();
                    }
                }
                else if (limbsCollisionChecker.rightFoot && limbsCollisionChecker.rightHand)
                {
                    float angle = Mathf.Atan2(finalY - (rightLeg.position.y + rightArm.position.y) / 2, finalX - (rightLeg.position.x + rightArm.position.x) / 2) * 180 / Mathf.PI - 90;

                    if (((angle <= (twoSameSideLimbs + showWarningDegree)) || (angle <= -(210 - showWarningDegree) - (twoSameSideLimbs / 2))))
                    {
                        showWarrining.ShowText(true);
                    }
                    else showWarrining.ShowText(false);

                    if (!((angle >= twoSameSideLimbs) && (angle <= (twoSameSideLimbs + twoSameSideLimbs/2)) || ((angle >= -210 - twoSameSideLimbs) && (angle <= -210 - (twoSameSideLimbs/ 2)))))
                    {
                        showWarrining.ShowText(true);
                        float angle2 = Mathf.Atan2(finalY - rightLeg.position.y, finalX - rightLeg.position.x) * 180 / Mathf.PI - 90;
                        if(angle2 <= -(singleLimb + extraOffset)|| angle2 >= (singleLimb + extraOffset))
                        {
                            Debug.LogError("Right Foot + arm: " + angle2);
                            fall.Fall();
                        }
                    }
                    
                }
                else if (limbsCollisionChecker.rightFoot && !limbsCollisionChecker.leftHand)
                {
                    float angle = Mathf.Atan2(finalY - rightLeg.position.y, finalX - rightLeg.position.x) * 180 / Mathf.PI - 90;
                    if (angle < -(singleLimb - showWarningDegree) || angle > (singleLimb - showWarningDegree))
                    {
                        showWarrining.ShowText(true);
                    }
                    else showWarrining.ShowText(false);
                    if (angle < -singleLimb || angle > singleLimb)
                    {
                        Debug.LogError("Right Foot");
                        fall.Fall();
                    }
                }
                else if (limbsCollisionChecker.leftFoot && limbsCollisionChecker.leftHand)
                {
                    float angle = Mathf.Atan2(finalY - (leftLeg.position.y + leftArm.position.y) / 2, finalX - (leftLeg.position.x + leftArm.position.x) / 2) * 180 / Mathf.PI - 90;

                    if (angle > -(twoSameSideLimbs - showWarningDegree) || angle < 2 * -twoSameSideLimbs + showWarningDegree)
                    {
                        showWarrining.ShowText(true);
                    }
                    else showWarrining.ShowText(false);

                    if (!(angle < -twoSameSideLimbs || angle > 2 * -twoSameSideLimbs))
                    {
                        
                        float angle2 = Mathf.Atan2(finalY - leftLeg.position.y, finalX - leftLeg.position.x) * 180 / Mathf.PI - 90;
                        if (angle2 <= -(singleLimb + extraOffset) || angle2 >= (singleLimb + extraOffset))
                        {
                            Debug.LogError("Left Foot + arm: " + angle2);
                            fall.Fall();
                        }
                    }
                    
                }
                else if (limbsCollisionChecker.leftFoot && !limbsCollisionChecker.rightHand)
                {
                    float angle = Mathf.Atan2(finalY - leftLeg.position.y, finalX - leftLeg.position.x) * 180 / Mathf.PI - 90;
                    if (angle < -(singleLimb - showWarningDegree) || angle > (singleLimb - showWarningDegree))
                    {
                        showWarrining.ShowText(true);
                    }
                    else showWarrining.ShowText(false);
                    if (angle < -singleLimb || angle > singleLimb)
                    {
                        Debug.LogError("Left Foot: " + angle);
                        fall.Fall();
                    }
                } else if((!limbsCollisionChecker.leftFoot && !limbsCollisionChecker.rightFoot) && limbsCollisionChecker.leftHand)
                {
                    float angle = Mathf.Atan2(leftArm.position.y - finalY, leftArm.position.x - finalX) * 180 / Mathf.PI - 90;
                    if (angle < -singleLimb || angle > singleLimb)
                    {
                        Debug.LogError("Left hand: " + angle);
                        fall.Fall();
                    }
                }
                else if ((!limbsCollisionChecker.leftFoot && !limbsCollisionChecker.rightFoot) && limbsCollisionChecker.rightHand)
                {
                    float angle = Mathf.Atan2(rightArm.position.y - finalY, rightArm.position.x - finalX) * 180 / Mathf.PI - 90;
                    if (angle < -singleLimb || angle > singleLimb)
                    {
                        Debug.LogError("Right hand: " + angle);
                        fall.Fall();
                    }
                }
            } else if(limbsCollisionChecker.LimbsTouching == 0) 
            {
                fall.Fall();
            }
        }
    }

    IEnumerator DeleyChecking()
    {
        yield return new WaitForSeconds(2f);
        isGameStarted = true;
    }
}

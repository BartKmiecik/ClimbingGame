using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScalingText : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(1, 1f).From(0, false, false).SetLoops(-1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWarrining : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    public void ShowText(bool show)
    {
        warningText.SetActive(show);
    }
}

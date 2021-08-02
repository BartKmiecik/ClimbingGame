using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIndicators : MonoBehaviour
{
    private List<GameObject> indicatorsList = new List<GameObject>();
    [SerializeField] private GameObject indicationEffects;

    public void Show (List<GameObject> handlersList)
    {
        indicatorsList.Clear();
        foreach (GameObject handle in handlersList)
        {
            GameObject temp = Instantiate(indicationEffects, handle.transform);
            indicatorsList.Add(temp);
        }
    }

    public void Hide()
    {
        foreach (GameObject obj in indicatorsList)
        {
            Destroy(obj);
        }
    }

}

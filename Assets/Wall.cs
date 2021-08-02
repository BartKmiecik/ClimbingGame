using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public List<Handle> handlesList = new List<Handle>();
    [SerializeField] private PersistableSO persistableSO;
    private void Start()
    {
        
    }

    public void LoadLevel(string levelName)
    {
        handlesList = persistableSO.LoadNewLevel(levelName);

        for(int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i));
        }

        foreach (Handle h in handlesList)
        {
            GameObject temp = Instantiate(h.scriptableHandle.prefabToInstantiate, transform);
            temp.GetComponentInChildren<Renderer>().material.color = h.handleColor;
            temp.transform.position = h.position;
            temp.transform.localScale = h.scale;
            temp.transform.rotation = h.rotation;
        }
    }

}

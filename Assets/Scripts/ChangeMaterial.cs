using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private Renderer holeMaterial;

    private void Awake()
    {
        holeMaterial = GetComponentInChildren<Renderer>();
    }

    public void ChangeMat(Material mat)
    {
        holeMaterial.material = mat;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavePosition
{
    public float x;
    public float y;
    public float z;

    public SavePosition(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

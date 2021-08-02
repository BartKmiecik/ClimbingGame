using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Handle 
{
    public ScriptableHandle scriptableHandle;
    public Color handleColor;
    public Vector3 position, scale;
    public Quaternion rotation;

    public Handle(ScriptableHandle scriptableHandle, Color handleColor, Vector3 position, Vector3 scale, Quaternion rotation)
    {
        this.scriptableHandle = scriptableHandle;
        this.handleColor = handleColor;
        this.position = position;
        this.scale = scale;
        this.rotation = rotation;
    }

}

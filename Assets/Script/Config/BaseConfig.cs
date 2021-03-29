using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseConfig: ScriptableObject
{
    public GameObject prefab;
    public string id;
    public virtual void Create()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/BaseConfig")]
public class BaseConfig: ScriptableObject
{
    public virtual List<BaseConfigAsset> GetData()
    {
        return null;
    }
}

public class BaseConfigAsset
{
    public GameObject prefab;
    public string id;
    public virtual IEnumerator Create()
    {
        yield return new WaitForSeconds(0);
    }
}

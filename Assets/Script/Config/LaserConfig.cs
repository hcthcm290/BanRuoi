using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/LaserConfig", fileName = "Laser Config")]
public class LaserConfig: BaseConfig
{
    public List<LaserConfigAsset> data;

    public override List<BaseConfigAsset> GetData()
    {
        return data.ConvertAll<BaseConfigAsset>(x => (BaseConfigAsset)x);
    }
}

[System.Serializable]
public class LaserConfigAsset:  BaseConfigAsset
{
    public float dps;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public float delay;

    public override IEnumerator Create()
    {
        yield return new WaitForSeconds(delay);

        EnemyLaser enemyLaser = GameObject.Instantiate(prefab).GetComponent<EnemyLaser>();
        enemyLaser.transform.position = startPosition;

        if(enemyLaser != null)
        {
            enemyLaser.DPS = dps;
        }
    }
}

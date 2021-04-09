using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/BossConfig", fileName = "Boss Config")]
public class BossConfig : BaseConfig
{
    [SerializeField]
    List<BossConfigAsset> bossConfigAsset;

    public override List<BaseConfigAsset> GetData()
    {
        return bossConfigAsset.ConvertAll<BaseConfigAsset>(x => (BaseConfigAsset)x);
    }
}

[System.Serializable]
public class BossConfigAsset : BaseConfigAsset
{
    [SerializeField] float delay;
    [SerializeField] Vector3 startPosition;
    [SerializeField] string BossName;
    [SerializeField] float health;

    public override IEnumerator Create()
    {
        yield return new WaitForSeconds(delay);

        GameObject boss = GameObject.Instantiate(prefab);
        boss.transform.position = startPosition;
        var bossHealth = boss.GetComponent<HealthBase>();
        bossHealth.maxHP = bossHealth.currentHP = health;

        TextDialog dialog = TextDialog._ins;

        if(dialog != null)
        {
            dialog.content = "Beware! The " + BossName + " is\ncoming!";
        }   dialog.Show();
    }
}

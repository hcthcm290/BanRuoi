using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner _ins;
    [SerializeField]
    SpawnEnemyBase[] listSpawner;
    [SerializeField]
    BossBehaviour bossBehaviour;

    [SerializeField]
    TextDialog textDialog;

    public int currentLv;

    // Start is called before the first frame update
    void Start()
    {
        currentLv = 1;
        _ins = this;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //if(totalWaveCount < 5 && currentSpawner == null)
        //{
        //    totalWaveCount++;

        //    int random = Random.Range(0, listSpawner.Length - 1);

        //    currentSpawner = Instantiate(listSpawner[random]);
        //}
        //if(totalWaveCount >= 5 && currentSpawner == null && textDialog != null)
        //{
        //    textDialog.content = "Beware! The Master of Puppets is\ncoming!";
        //    textDialog.Show();
        //    textDialog = null;
        //    bossBehaviour.enabled = true;
        //}
    }

    public void Spawn()
    {
        string Folder = "Lv" + currentLv.ToString();
        string File = "ConfigLv" + currentLv.ToString();
        var configData = Resources.Load(Folder + "/" + File);

        if (configData == null)
        {
            textDialog.content = "YOU WON!";
            textDialog.Show();
            return;
        }

        var data = (configData as GameConfig).baseConfigs;
        
        foreach (var ins in data)
        {
            var configs = ins.GetData();

            foreach (var config in configs)
            {
                IEnumerator enumerator = config.Create();
                StartCoroutine(enumerator);
            }
        }
    }
}

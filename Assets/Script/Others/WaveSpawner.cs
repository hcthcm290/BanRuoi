using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    SpawnEnemyBase[] listSpawner;
    [SerializeField]
    BossBehaviour bossBehaviour;

    [SerializeField]
    TextDialog textDialog;

    SpawnEnemyBase currentSpawner;

    WaveDatas data;

    int totalWaveCount;

    // Start is called before the first frame update
    void Start()
    {
        totalWaveCount = 0;
        bossBehaviour.enabled = false;

        //data = (Resources.Load("GameConfig") as GameConfig).data;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalWaveCount < 5 && currentSpawner == null)
        {
            totalWaveCount++;

            int random = Random.Range(0, listSpawner.Length - 1);

            currentSpawner = Instantiate(listSpawner[random]);
        }
        if(totalWaveCount >= 5 && currentSpawner == null && textDialog != null)
        {
            textDialog.content = "Beware! The Master of Puppets is\ncoming!";
            textDialog.Show();
            textDialog = null;
            bossBehaviour.enabled = true;
        }
    }

    void ParseData(WaveDatas data) 
    {
        
    }
}

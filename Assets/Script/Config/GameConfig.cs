using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Config/GameConfig", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] public List<BaseConfig> baseConfigs;

    //public WaveDatas data;

    public void OnValidate()
    {
        //baseConfigs.Clear();
        //baseConfigs.Add(CreateInstance<PinkyConfig>());
    }
}

[System.Serializable]
public class WaveDatas
{
    public int id;
    public List<WaveData> listData;
}

[System.Serializable]
public class WaveData
{
    public int id;
    [SerializeField] public BaseConfig config;
    public float delay;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo/Funny", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public WaveDatas data;
}

[System.Serializable]
public class WaveDatas
{
    public int id;
    public List<WaveData> data;
}

[System.Serializable]
public class WaveData
{
    public int id;

    public GameObject Prefabs;
    public float delay;
    public int maxNumber;
    public float interval;
}

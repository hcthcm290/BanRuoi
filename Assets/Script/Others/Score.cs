using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetFloat("score", 0);
        }
        score.text = PlayerPrefs.GetFloat("score").ToString();
    }
}

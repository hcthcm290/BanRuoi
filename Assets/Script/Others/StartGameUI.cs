using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    WaveSpawner waveSpawner;
    [SerializeField]
    GameObject playerCanon;
    [SerializeField]
    GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        waveSpawner.enabled = false;
        playerCanon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        playerMovement.enabled = true;
        playerCanon.SetActive(true);
        button.SetActive(false);

        waveSpawner.enabled = true;
    }
}

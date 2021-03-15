using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamShooting : MonoBehaviour
{
    [SerializeField]
    float delay;
    [SerializeField]
    float liveTime;
    private float startTime;


    [SerializeField]
    // Laser speed
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        delay = Random.Range(1.5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime < delay)
        {
            SetScaleX(0.01f);
        }
        if(Time.time - startTime >= delay && Time.time - startTime < delay + liveTime)
        {
            SetScaleX((Time.time - startTime - delay) * speed / 100);
        }
        if(Time.time - startTime >= delay + liveTime)
        {
            SetScaleX(1 - (Time.time - startTime - delay - liveTime) * speed / 100);
            startTime = Time.time;
        }
    }

    void SetScaleX(float value)
    {
        Vector3 scale = this.transform.localScale;

        scale.x = value;

        scale.x = Mathf.Clamp(scale.x, 0, 1);

        this.transform.localScale = scale;
    }
}

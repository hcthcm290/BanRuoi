using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float t;

    public float a;
    public float m;

    bool x;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        x = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;

        if(x == true)
        {
            pos = transform.position;

            pos.y += a * Time.deltaTime;
        }
        else
        {
            pos = transform.position;

            pos.y -= 2 * a * Time.deltaTime;
        }

        transform.position = pos;

        t += Time.deltaTime;
        if(t > m && t < 3*m/2)
        {
            x = false;
        }
        else
        {
            x = true;
        }

        if(t >= 3*m/2)
        {
            t = 0;
        }
    }
}

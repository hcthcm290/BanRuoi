using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField]
    BossNormalCanon[] bossNormalCanons;

    [SerializeField]
    BossTripleCanon[] bossTripleCanons;

    [SerializeField]
    Circle[] bossCircleCanon;

    [SerializeField]
    BossMovement bossMovement;

    [SerializeField]
    float movedownDuration;

    [SerializeField]
    float speed;

    [SerializeField]
    float normalCanonDuration;
    [SerializeField]
    float tripleDuration;
    [SerializeField]
    float circleDuration;
    [SerializeField]
    float comboDuration;
    float comboDelay;
    bool comboActivated;

    [SerializeField]
    float balanceFactor;

    [SerializeField]
    int stat;

    [SerializeField]
    HealthBase hp;

    // Start is called before the first frame update
    void Start()
    {
        bossMovement.enabled = false;
        hp.enabled = false;
        stat = -1;
        comboActivated = false;
        balanceFactor = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(movedownDuration > 0)
        {
            movedownDuration -= Time.deltaTime;
            this.transform.position += speed * Time.deltaTime * new Vector3(0, -1, 0);

            if (movedownDuration <= 0)
            {
                bossMovement.enabled = true;
                hp.enabled = true;
            }
        }
        else
        {
            if(hp.currentHP / hp.maxHP <= 0.4 && comboActivated == false)
            {
                DisableCanon(bossNormalCanons);
                DisableCanon(bossCircleCanon);
                DisableCanon(bossTripleCanons);

                stat = 4;
                comboDelay = 3;

                comboActivated = true;
            }


            if(stat == -1)
            {
                normalCanonDuration = Random.Range(3, 4.3f);
                ActivateCanon(bossNormalCanons);
                stat = 1;
            }
            else if(stat == 1)
            {
                normalCanonDuration -= Time.deltaTime;
                if(normalCanonDuration < 0)
                {
                    DisableCanon(bossNormalCanons);
                    float random = Random.Range(0.0f, 1.0f + balanceFactor);

                    if(random < 0.5)
                    {
                        ActivateCanon(bossTripleCanons);
                        tripleDuration = 7;
                        balanceFactor += 0.3f;
                        stat = 2;
                    }
                    else if (random >= 0.5)
                    {
                        ActivateCanon(bossCircleCanon);
                        circleDuration = 9;
                        balanceFactor -= 0.3f;
                        stat = 3;
                    }
                }
            }
            else if(stat == 2)
            {
                tripleDuration -= Time.deltaTime;
                if(tripleDuration < 0)
                {
                    normalCanonDuration = Random.Range(3, 4.3f);
                    ActivateCanon(bossNormalCanons);
                    stat = 1;
                }
            }
            else if (stat == 3)
            {
                circleDuration -= Time.deltaTime;
                if (circleDuration < 0)
                {
                    normalCanonDuration = Random.Range(3, 4.3f);
                    ActivateCanon(bossNormalCanons);
                    stat = 1;
                }
            }
            else if(stat == 4)
            {
                comboDelay -= Time.deltaTime;

                if (comboDelay <= 0)
                {
                    stat = 5;
                    comboDuration = 10;
                    ActivateCanon(bossCircleCanon);
                    ActivateCanon(bossTripleCanons);
                }
            }
            else if(stat == 5)
            {
                comboDuration -= Time.deltaTime;
                if(comboDuration <= 0)
                {
                    stat = -1;
                }
            }


        }
    }

    void ActivateCanon(BaseCanon[] l)
    {
        foreach(var canon in l)
        {
            canon.StartShooting();
        }
    }

    void DisableCanon(BaseCanon[] l)
    {
        foreach (var canon in l)
        {
            canon.StopShooting();
        }
    }

    private void OnDestroy()
    {
        var waveSpawner = WaveSpawner._ins;
        if(waveSpawner != null)
        {
            waveSpawner.currentLv++;
            waveSpawner.Spawn();
        }
    }
}

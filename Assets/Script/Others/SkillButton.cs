using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    [SerializeField] BaseCanon canonSkill;
    [SerializeField] float duration;
    private float cooldown = 0;

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void Use()
    {
        if(cooldown <= 0)
        {
            cooldown = duration;
            StartCoroutine("startShooting");
        }
    }

    IEnumerator startShooting()
    {
        canonSkill.enabled = true;
        canonSkill.StartShooting();

        yield return new WaitForSeconds(duration);

        canonSkill.StopShooting();
        canonSkill.enabled = false;
    }

    private void Start()
    {
        canonSkill.enabled = false;
    }
}

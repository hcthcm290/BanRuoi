using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PinkyConfig : BaseConfig
{
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Vector3[] targets;

    [SerializeField] public int numberOfPinky;
    [SerializeField] public int interval;

    public override void Create()
    {
        GameObject pinky = GameObject.Instantiate(prefab);
        pinky.transform.position = startPosition;

        PinkyMovement pkMovement = pinky.GetComponent<PinkyMovement>();
        if(pkMovement != null)
        {
            pkMovement.targets = targets;
        }

    }
}

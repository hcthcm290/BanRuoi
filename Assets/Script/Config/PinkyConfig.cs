using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/PinkyConfig", fileName = "Pinky Config")]
public class PinkyConfig : BaseConfig
{
    public List<PinkyConfigAsset> data;

    public override List<BaseConfigAsset> GetData()
    {
        return data.ConvertAll<BaseConfigAsset>(x => (BaseConfigAsset)x);
    }
}
[System.Serializable]
public class PinkyConfigAsset: BaseConfigAsset
{
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Vector3[] targets;

    [SerializeField] public int numberOfPinky;
    [SerializeField] public float interval;

    [SerializeField] public float delay;

    public override IEnumerator Create()
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfPinky; i++)
        {
            GameObject pinky = GameObject.Instantiate(prefab);
            pinky.transform.position = startPosition;

            PinkyMovement pkMovement = pinky.GetComponent<PinkyMovement>();
            if (pkMovement != null)
            {
                pkMovement.targets = targets;
            }

            yield return new WaitForSeconds(interval);
        }
    }
}

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
    [SerializeField] string pathName;

    [SerializeField] public int numberOfPinky;
    [SerializeField] public float interval;

    [SerializeField] public float delay;

    public override IEnumerator Create()
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < numberOfPinky; i++)
        {
            GameObject pinky = GameObject.Instantiate(prefab);
            //pinky.transform.position = startPosition;

            PinkyMovement pkMovement = pinky.GetComponent<PinkyMovement>();
            List<Vector3> paths = LoadPath(pathName);

            if (pkMovement != null)
            {
                pkMovement.targets = paths.ToArray();
            }
            pinky.transform.position = paths[0];

            yield return new WaitForSeconds(interval);
        }
    }

    public List<Vector3> LoadPath(string pathName)
    {
        List<Vector3> paths = new List<Vector3>();
        GameObject path = Resources.Load("Paths/" + pathName) as GameObject;

        for(int i=0; i < path.transform.childCount; i++)
        {
            paths.Add(path.transform.GetChild(i).transform.position);
        }

        return paths;
    }
}

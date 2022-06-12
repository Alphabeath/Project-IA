using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 size = new Vector3(1,1,1);

    public void PutTrunk(Vector3 pos)
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        transform.GetChild(0).position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

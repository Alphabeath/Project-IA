using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 size = new Vector3(1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        Vector3 pos;
        pos.x = 28.5f;
        pos.y = 6;
        pos.z = 27.5f;
        transform.GetChild(0).position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

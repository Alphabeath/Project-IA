using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinCubeGenScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 size = new Vector3(5, 5, 5);
    Vector3 pos = Vector3.zero;
    float[] heights;
    public float detail = 5;
    public float fineDetail = 0.1f;
    public Vector3 offset = Vector3.zero;
    Vector3 offsetInt = Vector3.zero;
    Vector3 offsetFrac = Vector3.zero;
    public float speed = 1;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        heights = new float[(int)(size.x * size.z)];
        for (int i = 0; i < (size.x * size.z); i++)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        }
    }

    void SetHeights()
    {
        fineDetail = detail * 0.01f;
        offsetInt.x = Mathf.Floor(offset.x);
        offsetInt.z = Mathf.Floor(offset.z);

        offsetFrac = offset - offsetInt;

        transform.position = Vector3.one;


        //offset.z += Time.deltaTime * speed;
        for (float z = 0; z < size.z; z++)
        {
            for (float x = 0; x < size.x; x++)
            {
                heights[(int)x + (int)z * (int)size.x] =
                    Mathf.Floor(Mathf.PerlinNoise(x * fineDetail + offsetInt.x * fineDetail, z * fineDetail + offsetInt.z * fineDetail) * 10);
                // GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // go.transform.position = new Vector3(i, perlinNoise * multiplier, j);
            }
        }
        PlaceCubes();
    }

    void PlaceCubes()
    {
        int i = 0;
        for (pos.z = 0.5f; pos.z < size.z; pos.z++)
        {
            for (pos.x = 0.5f; pos.x < size.x; pos.x++)
            {
                pos.y = heights[(int)pos.x + (int)pos.z * (int)size.x];
                transform.GetChild(i).localPosition = pos;
                i++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        SetHeights();
    }
}

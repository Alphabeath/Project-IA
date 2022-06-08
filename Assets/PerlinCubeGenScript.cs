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
    // jugador
	GameObject player;
	Vector3 terrainPos = Vector3.zero;
	Vector3 playerPos = Vector3.zero;
	Vector3 initialDiff = Vector3.zero;


    
    
    // Start is called before the first frame update
    void Start()
    {
        heights = new float[(int)(size.x * size.z)];
        for (int i = 0; i < (size.x * size.z); i++)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        }
		player = GameObject.FindGameObjectWithTag("Player");

		player.SetActive(false) ;
		player.transform.position = new Vector3(size.x * 0.5f, 15, size.z * 0.5f);
		player.SetActive(true) ;

		initialDiff = player.transform.position - transform.position;
		initialDiff.y = 0;
		initialDiff.x = Mathf.Floor( initialDiff.x );
		initialDiff.z = Mathf.Floor( initialDiff.z );

		playerPos.x = Mathf.Floor( player.transform.position.x ); 
		playerPos.z = Mathf.Floor( player.transform.position.z );
		playerPos.y = 0;
		terrainPos = playerPos - initialDiff;
		transform.position = terrainPos;
    }

    void SetHeights()
    {
        fineDetail = detail * 0.01f;
        for (float z = 0; z < size.z; z++)
        {
            for(float x = 0; x < size.x; x++)
            {
                heights[(int)x + (int)z * (int)size.x] =
                    Mathf.PerlinNoise(x * fineDetail, z * fineDetail) * 10;
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

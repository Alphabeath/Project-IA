using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 size = new Vector3(1.5f,5,1.5f);
    public int total_hijos;
    private int ultimo_hijo;    

    void Start()
    {
        PerlinCubeGenScript terrain = FindObjectOfType<PerlinCubeGenScript>();
        size = terrain.size;
        for (int i = 0; i < (terrain.size.x * terrain.size.z); i++)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        }
        ultimo_hijo = 0;
    }

    public void PutTrunk(Vector3 pos)
    {   
        transform.GetChild(ultimo_hijo).position = pos;
        ++ultimo_hijo;
        total_hijos = ultimo_hijo + 1;
    }

    public void PutTrunks()
    {
        PerlinCubeGenScript terrain = FindObjectOfType<PerlinCubeGenScript>();
        var pos = new Vector3(terrain.pos.x, terrain.pos.y, terrain.pos.z);
        int i = 0;
        for (pos.z = 0.5f; pos.z < size.z; pos.z++)
        {
            for (pos.x = 0.5f; pos.x < size.x; pos.x++)
            {
                var indGrid = (int)pos.x + (int)pos.z * (int)size.x;                                
                var perlinValue = terrain.perlinNoiseValues[indGrid];
                pos.y = terrain.heights[indGrid] + 1;
                if ((pos.y > 4) && (perlinValue > 0.5))
                {
                    transform.GetChild(i).localPosition = pos;
                    i++;
                }                
            }
        }
    }

    public void ChangePosition(Vector3 pos, int hijo)
    {
        transform.GetChild(hijo).position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        ultimo_hijo = 0;
    }
    public void PutTrunk(Vector3 pos)
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        transform.GetChild(ultimo_hijo).position = pos;
        ++ultimo_hijo;
        total_hijos = ultimo_hijo + 1;
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

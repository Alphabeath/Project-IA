using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMoveScript : MonoBehaviour
{
    public float elapseTime = 0f;
    public float perlinNoise = 0f;
    public float multiplier = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapseTime = Time.time;
        perlinNoise = Mathf.PerlinNoise(elapseTime, 0);
        transform.position = new Vector3(transform.position.x, perlinNoise * multiplier, transform.position.z);  
    }
}

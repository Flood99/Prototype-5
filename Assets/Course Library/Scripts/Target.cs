using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4 ;
    private float ySpawnPos = -6;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(),ForceMode.Impulse);
        rb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), 6);
    }
    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(maxSpeed,minSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}

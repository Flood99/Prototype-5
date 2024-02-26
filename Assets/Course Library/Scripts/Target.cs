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
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosion;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(),ForceMode.Impulse);
        rb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), -1);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if(gameManager.isGameActive == true)
        {
            Destroy(gameObject);
            Instantiate(explosion,transform.position,explosion.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}

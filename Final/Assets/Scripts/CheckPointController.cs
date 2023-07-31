using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    public GameObject spawnPoint;
    public Transform spawnLocation;

    public GameObject[] checkpoints = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {

        spawnPoint = GameObject.Find("SpawnPoint");
        spawnLocation = spawnPoint.transform;
        Debug.Log(spawnPoint.transform.position);
        this.transform.position = spawnLocation.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPoint")
        {
            Debug.Log("Here");
            GameObject currentCheckpoint = GameObject.Find(other.name);
            spawnLocation = currentCheckpoint.transform;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Debug.Log("On terrain");
            Respawn();
        }
    }

    public void Respawn()
    {
        this.transform.position = spawnLocation.position;
    }
}

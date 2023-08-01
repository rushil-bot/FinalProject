using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //Debug.Log(spawnPoint.transform.position);
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
            //Debug.Log("Here");
            GameObject currentCheckpoint = GameObject.Find(other.name);
            spawnPoint = currentCheckpoint;
            spawnLocation = currentCheckpoint.transform;
        }

        if(other.name == "EndPoint")
        {
            Debug.Log("Level Completed!");
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            Respawn();
        }

        if(collision.gameObject.tag == "Spikes")
        {
            Respawn();
        }


    }

    public void Respawn()
    {
        this.transform.position = spawnLocation.position;
    }
}

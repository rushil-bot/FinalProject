using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControllerTwo : MonoBehaviour
{

    public GameObject canvas;
    public GameObject lossPanel;
    public GameObject spawnPoint;
    public Transform spawnLocation;

    public GameObject ava;
    public Avalanche avalanche;

    public GameObject[] checkpoints = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {


        spawnPoint = GameObject.Find("SpawnPoint");
        spawnLocation = spawnPoint.transform;

        ava = GameObject.Find("Avalanche");
        avalanche = ava.GetComponent<Avalanche>();
        //Debug.Log(spawnPoint.transform.position);
        this.transform.position = spawnLocation.position;

        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        lossPanel.SetActive(false);
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

        if (other.name == "EndPoint")
        {
            Debug.Log("Level Completed!");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            if(spawnLocation.position.x <= ava.transform.position.x)
            {
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Unlocked Cursor");
                Cursor.visible = true;
                Debug.Log("Visible cursor");
            }
            else
            {
                Respawn();
            }

        }

        if (collision.gameObject.tag == "Spikes")
        {
            Respawn();
        }


    }

    public void Respawn()
    {
        this.transform.position = spawnLocation.position;
    }
}

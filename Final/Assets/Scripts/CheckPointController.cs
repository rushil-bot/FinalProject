using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointController : MonoBehaviour
{

    public GameObject spawnPoint;
    public Transform spawnLocation;

    public GameObject canvas;
    public GameObject lossPanel;

    public GameObject water;

    public GameObject[] checkpoints = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {

        spawnPoint = GameObject.Find("SpawnPoint");
        spawnLocation = spawnPoint.transform;

        water = GameObject.Find("Water");
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
            if (water.transform.position.y >= spawnLocation.position.y)
            {
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Respawn();
            }
        }

        if(collision.gameObject.tag == "Spikes")
        {
            if (water.transform.position.y >= spawnLocation.position.y)
            {
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Respawn();
            }
        }


    }

    public void Respawn()
    {
        this.transform.position = spawnLocation.position;
    }
}

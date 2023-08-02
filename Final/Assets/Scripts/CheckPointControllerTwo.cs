using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControllerTwo : MonoBehaviour
{

    public GameObject canvas;
    public GameObject lossPanel;
    public GameObject winPanel;

    public GameObject spawnPoint;
    public Transform spawnLocation;

    public GameObject ava;
    public Avalanche avalanche;

    public AudioSource audio;

    public GameObject player;
    public AudioSource playerAudio;

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
        winPanel = canvas.transform.Find("GameWinPanel").gameObject;

        audio = avalanche.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerAudio = player.GetComponent<AudioSource>();

        lossPanel.SetActive(false);
        winPanel.SetActive(false);
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
            winPanel.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            playerAudio.Play();
            if (spawnLocation.position.x <= ava.transform.position.x)
            {
                
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                audio.Stop();
            }
            else
            {
                Respawn();
            }

        }

        if (collision.gameObject.tag == "Spikes")
        {
            playerAudio.Play();
            if (spawnLocation.position.x <= ava.transform.position.x)
            {
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                audio.Stop();
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

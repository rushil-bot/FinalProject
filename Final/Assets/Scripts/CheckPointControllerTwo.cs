using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControllerTwo : MonoBehaviour
{

    public GameObject canvas;
    public GameObject lossPanel;
    public GameObject winPanel;
    public GameObject closePanel;

    public AudioSource winAudio;
    public AudioSource lossAudio;

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
        closePanel = canvas.transform.Find("ClosePanel").gameObject;

        audio = avalanche.GetComponent<AudioSource>();

        lossAudio = lossPanel.GetComponent<AudioSource>();
        winAudio = winPanel.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerAudio = player.GetComponent<AudioSource>();

        lossPanel.SetActive(false);
        winPanel.SetActive(false);
        closePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, ava.transform.position);
        if (distance < 25)
        {
            closePanel.SetActive(true);
        }
        else
        {
            closePanel.SetActive(false);
        }

        if (lossPanel.activeSelf || winPanel.activeSelf)
        {
            closePanel.SetActive(false);
        }
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
            winAudio.Play();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            playerAudio.Play();
            if (spawnLocation.position.x <= ava.transform.position.x)
            {
                audio.Stop();
                lossPanel.SetActive(true);
                lossAudio.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
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
                audio.Stop();
                lossPanel.SetActive(true);
                lossAudio.Play();
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

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
    public GameObject winPanel;
    public GameObject closePanel;

    public AudioSource winAudio;
    public AudioSource lossAudio;

    public GameObject water;

    public AudioSource audio;

    public GameObject player;
    public AudioSource playerAudio;

    public LayerMask waterRising;

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
        winPanel = canvas.transform.Find("GameWinPanel").gameObject;
        closePanel = canvas.transform.Find("ClosePanel").gameObject;

        winAudio = winPanel.GetComponent<AudioSource>();
        lossAudio = lossPanel.GetComponent<AudioSource>();

        audio = water.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerAudio = player.GetComponent<AudioSource>();


        lossPanel.SetActive(false);
        winPanel.SetActive(false);
        closePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //int layerMask = 1 << 11;

        // This would cast rays only against colliders in layer 8.

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5, waterRising))
        {
            closePanel.SetActive(true);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

        }
        else
        {
            closePanel.SetActive(false);
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            //Debug.Log("Did not Hit");
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

        if(other.name == "EndPoint")
        {
            winPanel.SetActive(true);
            closePanel.SetActive(false);
            audio.Stop();
            winAudio.Play();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            playerAudio.Play();
            if (water.transform.position.y >= spawnLocation.position.y)
            {
                lossPanel.SetActive(true);
                closePanel.SetActive(false);
                lossAudio.Play();
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
                audio.Stop();
                playerAudio.Play();
                closePanel.SetActive(false);
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

    public void NextLevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}

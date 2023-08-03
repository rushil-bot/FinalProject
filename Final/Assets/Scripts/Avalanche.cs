using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avalanche : MonoBehaviour
{
    public GameObject canvas;
    public GameObject lossPanel;

    public AudioSource audio;

    public GameObject avalanche;
    public GameObject clouds;
    public Vector3 hiddenPosition;
    public float moveSpeed = 5f;
    public bool startMove = false;

    public GameObject player;
    public AudioSource playerAudio;
    public CheckPointControllerTwo checkPointController;

    public AudioSource lossAudio;


    void Start()
    {
        
        player = GameObject.Find("Player");
        checkPointController = player.GetComponent<CheckPointControllerTwo>();

        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;

        lossAudio = lossPanel.GetComponent<AudioSource>();
        lossPanel.SetActive(false);
        
        avalanche = GameObject.Find("Avalanche");
        clouds = GameObject.Find("CloudParticleSystem");
        hiddenPosition = avalanche.transform.position + new Vector3(352.0f, 0, 0);

        audio = avalanche.GetComponent<AudioSource>();

        playerAudio = player.GetComponent<AudioSource>();
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        clouds.transform.position = Vector3.MoveTowards(clouds.transform.position, hiddenPosition, step);
        avalanche.transform.position = Vector3.MoveTowards(avalanche.transform.position, hiddenPosition, step);

        if (lossPanel.activeSelf)
        {
            avalanche.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAudio.Play();
            if (avalanche.transform.position.x >= checkPointController.spawnLocation.position.x)
            {
                audio.Stop();
                lossPanel.SetActive(true);
                lossAudio.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
               
            }
            else
            {
                checkPointController.Respawn();
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject canvas;
    public GameObject lossPanel;

    public GameObject ava;
    public CheckPointControllerTwo checkPointController;

    public GameObject player;
    public AudioSource playerAudio;

    public AudioSource lossAudio;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {

        checkPointController = this.GetComponent<CheckPointControllerTwo>();

        ava = GameObject.Find("Avalanche");

        audio = ava.GetComponent<AudioSource>();
        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;

        lossAudio = lossPanel.GetComponent<AudioSource>();
        lossPanel.SetActive(false);


        
        player = GameObject.Find("Player");
        playerAudio = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PaintBall")
        {
            playerAudio.Play();
            if (ava.transform.position.y >= checkPointController.spawnLocation.position.y)
            {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Mob");
                foreach (GameObject go in gos)
                    Destroy(go);
                gos = GameObject.FindGameObjectsWithTag("PaintBall");
                foreach (GameObject go in gos)
                    Destroy(go);
                audio.Stop();
                lossPanel.SetActive(true);
                lossAudio.Play();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                checkPointController.Respawn();
                Destroy(other);
            }
        }

        if (other.tag == "Mob")
        {
            playerAudio.Play();
            if (ava.transform.position.y >= checkPointController.spawnLocation.position.y)
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

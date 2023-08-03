using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLevelOne : MonoBehaviour
{
    public CheckPointController checkPointController;

    public GameObject canvas;
    public GameObject lossPanel;
    public GameObject closePanel;

    public GameObject water;

    public GameObject player;
    public AudioSource playerAudio;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        checkPointController = this.GetComponent<CheckPointController>();
        water = GameObject.Find("Water");

        audio = water.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        playerAudio = player.GetComponent<AudioSource>();

        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        closePanel = canvas.transform.Find("ClosePanel").gameObject;
        lossPanel.SetActive(false);

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -5)
        {
            playerAudio.Play();
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
            {
                audio.Stop();
                lossPanel.SetActive(true);
                closePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.SetActive(false);
            }
            else
            {
                checkPointController.Respawn();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PaintBall")
        {
            playerAudio.Play();
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
            {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Mob");
                foreach (GameObject go in gos)
                    Destroy(go);
                gos = GameObject.FindGameObjectsWithTag("PaintBall");
                foreach (GameObject go in gos)
                    Destroy(go);
                audio.Stop();
                lossPanel.SetActive(true);
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
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
            {
                audio.Stop();
                lossPanel.SetActive(true);
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

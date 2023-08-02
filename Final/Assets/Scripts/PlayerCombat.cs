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
    // Start is called before the first frame update
    void Start()
    {

        checkPointController = this.GetComponent<CheckPointControllerTwo>();

        ava = GameObject.Find("Avalanche");
        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
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
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Destroy(other);
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

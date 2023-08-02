using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avalanche : MonoBehaviour
{
    public GameObject canvas;
    public GameObject lossPanel;

    public GameObject avalanche;
    public Vector3 hiddenPosition;
    public float moveSpeed = 5f;
    public bool startMove = false;

    public GameObject player;
    public CheckPointControllerTwo checkPointController;


    void Start()
    {

        player = GameObject.Find("Player");
        checkPointController = player.GetComponent<CheckPointControllerTwo>();

        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        lossPanel.SetActive(false);
        
        avalanche = GameObject.Find("Avalanche");
        hiddenPosition = avalanche.transform.position + new Vector3(352.0f, 0, 0);
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        avalanche.transform.position = Vector3.MoveTowards(avalanche.transform.position, hiddenPosition, step);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (avalanche.transform.position.x >= checkPointController.spawnLocation.position.x)
            {
                lossPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Cursor unlocked");
                Cursor.visible = true;
                Debug.Log("Cursor Visible");
            }
            else
            {
                checkPointController.Respawn();
            }

        }
    }
}

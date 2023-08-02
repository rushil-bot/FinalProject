using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLevelOne : MonoBehaviour
{
    public CheckPointController checkPointController;

    public GameObject canvas;
    public GameObject lossPanel;

    public GameObject water;


    // Start is called before the first frame update
    void Start()
    {
        checkPointController = this.GetComponent<CheckPointController>();
        water = GameObject.Find("Water");
        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        lossPanel.SetActive(false);

        

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PaintBall")
        {
            Debug.Log("paintball hit");
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
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
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
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

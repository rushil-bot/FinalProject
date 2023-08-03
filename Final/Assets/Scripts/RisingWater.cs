using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    public GameObject canvas;
    public GameObject lossPanel;
    public GameObject closePanel;

    public AudioSource lossAudio;

    public GameObject player;
    public CheckPointController checkPointController;

    public GameObject water;
    public Vector3 hiddenPosition;
    public float riseSpeed = 1.0f;
    public bool startRise = false;

    public AudioSource playerAudio;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        checkPointController = player.GetComponent<CheckPointController>();
        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        closePanel = canvas.transform.Find("ClosePanel").gameObject;
        lossAudio = lossPanel.GetComponent<AudioSource>();
        lossPanel.SetActive(false);
        
        water = GameObject.Find("Water");

        audio = water.GetComponent<AudioSource>();



        playerAudio = player.GetComponent<AudioSource>();
        hiddenPosition = water.transform.position + new Vector3(0, 33.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(timer());
        if(startRise)
        {
            float step = riseSpeed * Time.deltaTime;
            water.transform.position = Vector3.MoveTowards(water.transform.position, hiddenPosition, step);
        }
        if (lossPanel.activeSelf)
        {
            water.SetActive(false);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(4f);
        startRise = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playerAudio.Play();
           
            if (water.transform.position.y >= checkPointController.spawnLocation.position.y)
            {
                audio.Stop();
                lossPanel.SetActive(true);
                closePanel.SetActive(false);
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

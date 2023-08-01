using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    public GameObject canvas;
    public GameObject lossPanel;

    public GameObject water;
    public Vector3 hiddenPosition;
    public float riseSpeed = 0.5f;
    public bool startRise = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        lossPanel = canvas.transform.Find("GameOverPanel").gameObject;
        lossPanel.SetActive(false);
        
        water = GameObject.Find("Water");
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
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(3.0f);
        startRise = true;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Player")
        {
            lossPanel.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    public bool beginTrap = false;

    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject spike4;
    public GameObject spike5;
    public GameObject spike6;
    public GameObject spike7;
    public GameObject spike8;
    public GameObject spike9;
    public GameObject spike10;
    public GameObject spike11;
    public GameObject spike12;

    // Start is called before the first frame update
    void Start()
    {
        spike1 = GameObject.Find("spikes1");
        spike2 = GameObject.Find("spikes2");
        spike3 = GameObject.Find("spikes3");
        spike4 = GameObject.Find("spikes4");
        spike5 = GameObject.Find("spikes5");
        spike6 = GameObject.Find("spikes6");
        spike7 = GameObject.Find("spikes7");
        spike8 = GameObject.Find("spikes8");
        spike9 = GameObject.Find("spikes9");
        spike10 = GameObject.Find("spikes10");
        spike11 = GameObject.Find("spikes11");
        spike12 = GameObject.Find("spikes12");

        spike1.SetActive(false);
        spike2.SetActive(false);
        spike3.SetActive(false);
        spike4.SetActive(false);
        spike5.SetActive(false);
        spike6.SetActive(false);
        spike7.SetActive(false);
        spike8.SetActive(false);
        spike9.SetActive(false);
        spike10.SetActive(false);
        spike11.SetActive(false);
        spike12.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(test());
        if(beginTrap)
        {
            StartCoroutine(AlternateSpikes());
        }
    }

    IEnumerator AlternateSpikes()
    {
        spike1.SetActive(true);
        spike4.SetActive(true);
        spike7.SetActive(true);
        spike6.SetActive(true);
        spike9.SetActive(true);
        spike12.SetActive(true);

        spike2.SetActive(false);
        spike3.SetActive(false);
        spike5.SetActive(false);
        spike8.SetActive(false);
        spike10.SetActive(false);
        spike11.SetActive(false);

        yield return new WaitForSeconds(2.0f);

        spike1.SetActive(false);
        spike4.SetActive(false);
        spike7.SetActive(false);
        spike6.SetActive(false);
        spike9.SetActive(false);
        spike12.SetActive(false);

        spike2.SetActive(true);
        spike3.SetActive(true);
        spike5.SetActive(true);
        spike8.SetActive(true);
        spike10.SetActive(true);
        spike11.SetActive(true);

        beginTrap = false;
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(2.0f);
        beginTrap = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "spike")
        {
            Debug.Log("HIT");
        }
    }
}

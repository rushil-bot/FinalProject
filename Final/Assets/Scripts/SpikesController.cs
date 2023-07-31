using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{

    public GameObject spikes;

    public bool beginTrap = false;
    // Start is called before the first frame update
    void Start()
    {
        spikes = GameObject.Find("spikes");
        spikes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(test());
        if (beginTrap)
        {
            StartCoroutine(AlternateSpikes());
        }

    }

    IEnumerator AlternateSpikes()
    {
        spikes.SetActive(true);

        yield return new WaitForSeconds(1.5f);


        spikes.SetActive(false);
        beginTrap = false;
    }


    IEnumerator test()
    {
        yield return new WaitForSeconds(1.5f);
        beginTrap = true;
    }
}

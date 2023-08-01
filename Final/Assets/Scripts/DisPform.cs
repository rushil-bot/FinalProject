using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisPform : MonoBehaviour
{

    public GameObject pform1;
    public GameObject pform2;

    public bool beginTrap = false;
    // Start is called before the first frame update
    void Start()
    {
        pform1 = GameObject.Find("DisBlock1");
        pform2 = GameObject.Find("DisBlock2");

        pform1.SetActive(true);
        pform2.SetActive(true);
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
        pform1.SetActive(false);
        pform2.SetActive(false);

        yield return new WaitForSeconds(2.0f);


        pform1.SetActive(true);
        pform2.SetActive(true);
        beginTrap = false;
    }


    IEnumerator test()
    {
        yield return new WaitForSeconds(2.0f);
        beginTrap = true;
    }
}

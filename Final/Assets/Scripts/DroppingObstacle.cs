using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObstacle : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    
    public Vector3 hiddenPosition1;
    public Vector3 hiddenPosition2;
    public Vector3 hiddenPosition3;
    public Vector3 hiddenPosition4;

    public bool boxDrop = false;
    
    public float dropSpeed1 = 3f;
    public float dropSpeed2 = 2.5f;
    public float dropSpeed3 = 2f;
    public float dropSpeed4 = 1f;

    // Start is called before the first frame update
    void Start()
    {
        box1 = GameObject.Find("dropCrate1");
        box2 = GameObject.Find("dropCrate2");
        box3 = GameObject.Find("dropCrate3");
        box4 = GameObject.Find("dropCrate4");
        hiddenPosition1 = box1.transform.position + new Vector3(0, -10.0f, 0);
        hiddenPosition2 = box2.transform.position + new Vector3(0, -10.0f, 0);
        hiddenPosition3 = box3.transform.position + new Vector3(0, -10.0f, 0);
        hiddenPosition4 = box4.transform.position + new Vector3(0, -10.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(boxDrop)
        {
            float step1 = dropSpeed1 * Time.deltaTime;
            float step2 = dropSpeed2 * Time.deltaTime;
            float step3 = dropSpeed3 * Time.deltaTime;
            float step4 = dropSpeed4 * Time.deltaTime;

            box1.transform.position = Vector3.MoveTowards(box1.transform.position, hiddenPosition1, step1);
            box2.transform.position = Vector3.MoveTowards(box2.transform.position, hiddenPosition2, step2);
            box3.transform.position = Vector3.MoveTowards(box3.transform.position, hiddenPosition3, step3);
            box4.transform.position = Vector3.MoveTowards(box4.transform.position, hiddenPosition4, step4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="dropButton")
        {
            boxDrop = true;
        }
    }
}

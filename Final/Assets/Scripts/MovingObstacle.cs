using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public GameObject platform;

    public Vector3 hiddenPosition;

    public bool platformMove = false;

    public float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.Find("movingPlatform");
        hiddenPosition = platform.transform.position + new Vector3(24f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(platformMove)
        {
            float step = moveSpeed * Time.deltaTime;
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, hiddenPosition, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="movingButton")
        {
            platformMove = true;
        }
    }
}

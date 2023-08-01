using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    
    [SerializeField]
    private WaypointPath waypointPath;

    [SerializeField]
    private float speed;

    private int targetWaypointIndex;

    private Transform previosWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    public int seconds;
    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
        //Invoke("TargetNextWaypoint",seconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        this.transform.position = Vector3.Lerp(previosWaypoint.position, targetWaypoint.position, elapsedPercentage);
        this.transform.rotation = Quaternion.Lerp(previosWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage);


        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previosWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previosWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    /*
    IEnumerator waiter()
    {

        //Wait for 4 seconds
        yield return new WaitForSeconds(seconds);

    }
    */
    /*private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(null);
    }
    */

}

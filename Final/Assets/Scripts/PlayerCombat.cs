using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public CheckPointController checkPointController;
    // Start is called before the first frame update
    void Start()
    {

        checkPointController = this.GetComponent<CheckPointController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PaintBall")
        {
            checkPointController.Respawn();
        }

        if(other.tag == "Mob")
        {
            checkPointController.Respawn();
        }
    }
}

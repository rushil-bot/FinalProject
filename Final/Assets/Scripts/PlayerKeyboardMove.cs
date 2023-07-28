using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    Rigidbody rigidBody;

    float moveSpeed = 7;
    float jumpForce = 10;
    bool isJumping = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * -transform.right * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += -moveSpeed * transform.forward * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * transform.right * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(!isJumping)
            {
                isJumping = true;
                rigidBody.AddForce(transform.up * jumpForce);
            }
        }
    }
}

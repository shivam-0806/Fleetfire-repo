using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=12f;
    public CharacterController controller;
    public float gravity=-9.8f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x + transform.forward*z;
        //dir in which player will move

        controller.Move(move*moveSpeed*Time.deltaTime);
        //character controller me gravity hoti hi nhi h
        // gravity code krni padti h

        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundLayer);
        //make a sphere on feet of our player
        if (isGrounded&&velocity.y<0){
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump")&&isGrounded){
            velocity.y=Mathf.Sqrt(-2f*gravity*jumpHeight);
        }
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}

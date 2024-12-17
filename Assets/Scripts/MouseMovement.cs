using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float sensitivity;// control sensitivity
    float xRotation=0f;
    //float yRotation=0f;
    public Transform playerBody;//jab LR move krenge to body move krenge
    //jab up down to sirf camera
    public float TopClamp=-60f; //upper rotation limit, gol thori ghumega
    public float BottomClamp=60f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // so that cursor nhi dikhe invisible
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;
        // time.deltatime e frame independent hojata h

        xRotation-=mouseY;//upar pe -ve hoga to upar dekhega
        xRotation = Mathf.Clamp(xRotation,TopClamp,BottomClamp);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //add this line to camera

        //sideways
        //yRotation += mouseX;    galat
        playerBody.Rotate(Vector3.up*mouseX);// vector3.up se y-axis access kia
        // yRotation = Mathf.Clamp(yRotation,TopClamp,BottomClamp);
        // transform.localRotation = Quaternion.Euler(xRotation,0f,0f);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    Vector3 forwardDir;
    Vector3 rightDir;
    Vector3 myForwardDir;

    bool IsGrounded;
    float floordist;
    //Vector3 CameraYrot;

    Transform Camera;
    void Start ()
    {
       
        Camera = GetComponentInChildren<Camera>().transform;
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + (forwardDir + rightDir) * speed * 2 );
        }
        else { rb.MovePosition(transform.position + (forwardDir + rightDir) * speed); }
    }

	void Update ()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        
        forwardDir = gameObject.transform.forward * vert;
        rightDir = Camera.transform.right * horz;


        RaycastHit hit;

        Physics.Raycast(Ray, hit, floordist);
        //gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, Camera.transform.rotation.y, gameObject.transform.rotation.z);


       // Debug.Log(horz + " " + vert);
        //GetComponent<Rigidbody>().MovePosition(transform.position + dirVector * Time.deltaTime);
	}
}

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

    //Vector3 CameraYrot;

    Transform Camera;
    void Start ()
    {
       // Debug.Log(transform.childCount);
       // CameraX = this.gameObject.transform.GetChild(0);
        Camera = GetComponentInChildren<Camera>().transform;
       // Debug.Log(CameraX.transform.childCount);
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        //Debug.Log((forwardDir + rightDir) * speed );
        //rb.AddForce((forwardDir + rightDir) * speed );
        rb.MovePosition(transform.position + (forwardDir + rightDir) * speed );
    }

	void Update ()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        forwardDir = Camera.transform.forward * vert;
        rightDir = Camera.transform.right * horz;

        gameObject.transform.rotation = Camera.transform.rotation;


       // Debug.Log(horz + " " + vert);
        //GetComponent<Rigidbody>().MovePosition(transform.position + dirVector * Time.deltaTime);
	}
}

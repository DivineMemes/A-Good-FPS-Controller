using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float lookX;
    public float lookY;
    public float speed = 3f;
    public Camera cam; 
    void Update()
    {

        gameObject.transform.rotation *= Quaternion.Euler(gameObject.transform.rotation.x, cam.transform.rotation.y, gameObject.transform.rotation.z);

    }
}

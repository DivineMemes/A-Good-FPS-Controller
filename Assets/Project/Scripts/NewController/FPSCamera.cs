using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float speedH;
    public float speedV;

    public float yaw;
    public float pitch;
    //public bool clamprot;
    public float minPitch;
    public float maxPitch;
    public GameObject Player;
    public Camera cam;
    public Quaternion CharTargetRot;
    public Quaternion CamTargetRot;

    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    private void Start()
    {
        CharTargetRot = Player.gameObject.transform.localRotation;
        CamTargetRot = cam.transform.localRotation;
    }
    float ClampAngle(float angle, float from, float to)
    {
        if (angle > 180) angle = 360 - angle;
        angle = Mathf.Clamp(angle, from, to);
        if (angle < 0) angle = 360 + angle;

        return angle;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * speedH;
        pitch -= Input.GetAxis("Mouse Y") * speedV;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        CharTargetRot = Quaternion.Euler(0f, yaw, 0f);//sets the horizontal rotation for the player using generic Input mouse control
        CamTargetRot = Quaternion.Euler(pitch, 0f, 0f);//sets the vertical rotation for the mouse using generic Input mouse control


        Player.transform.localRotation = CharTargetRot;//tells the player to match the rotation dictated by the mouse
        cam.transform.localRotation = CamTargetRot;//^ same for camera
        //if (clamprot)
        //{
        //    CamTargetRot = ClampRotationAroundXAxis(CamTargetRot);//clamps the vertical rotation so as to not circle
        //}
        UpdateCursorLock();
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    //Quaternion ClampRotationAroundXAxis(Quaternion q)
    //{
    //    q.x /= q.w;
    //    q.y /= q.w;
    //    q.z /= q.w;
    //    q.w = 1.0f;
    //    float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
    //    angleX = Mathf.Clamp(angleX, minPitch, maxPitch);
    //    q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
    //    return q;
    //}//quick quaternion function to clamp around the X axis
}

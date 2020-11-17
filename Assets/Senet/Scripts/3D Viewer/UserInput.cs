using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static bool isOnAuto = false;

    [Tooltip("Place object named 'UserCameraBase' here. \nBaseForRotation > UserCameraBase")]
    public Transform cameraUserBaseLoc;
    [Tooltip("Place object named 'AutoCameraBase' here. \nBaseForRotation > AutoCameraBase")]
    public Transform cameraAutoBaseLoc;
    [Tooltip("Place object named 'Main Camera' here. \nBaseForRotation > Main Camera")]
    public new Transform camera;
    public float speed = 100f;
    public float maxClamp = 10f;
    public float rotateSpeed = 10f;

    private ModelOrganizer organizer;
    private Transform children;
    private float zoomAmount = 0f;
    private float autoRotateFractionAmount = 10f;
    private bool hasStarted = false;

    private void Start()
    {
        if (this.transform.childCount >= 2)
        {
            children = this.transform.GetChild(0);
            organizer = children.GetComponent<ModelOrganizer>();
            /*
            cameraBaseLoc = this.transform.GetChild(1);
            camera = cameraBaseLoc.transform.GetChild(0);
            */
        }
        /*
        organizer = this.GetComponentInChildren<ModelOrganizer>();
        children = transform.GetComponentInChildren<Transform>();
        */
    }

    void Update ()
    {
        if (!isOnAuto)
        {
            MouseInput();
            CheckKeyInput();
        }
        else
        {
            AutoRotate();
        }
	}

    public void ChangeAuto()
    {
        if(isOnAuto)
        {
            isOnAuto = false;
            camera.transform.position = cameraUserBaseLoc.transform.position;
            camera.transform.rotation = cameraUserBaseLoc.transform.rotation;
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            isOnAuto = true;
            camera.transform.position = cameraAutoBaseLoc.transform.position;
            camera.transform.rotation = cameraAutoBaseLoc.transform.rotation;
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }

    private void MouseInput()
    {
        children.Rotate(new Vector3(Input.GetAxis("Mouse Y"),
            -1 * Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed, Space.World);
        zoomAmount += Input.GetAxis("Mouse ScrollWheel");
        zoomAmount = Mathf.Clamp(zoomAmount, -maxClamp, maxClamp);
        float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")),
            maxClamp - Mathf.Abs(zoomAmount));
        camera.transform.Translate(0, 0, translate * rotateSpeed * Mathf.Sign(
            Input.GetAxis("Mouse ScrollWheel")));
    }

    private void CheckKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            organizer.BackOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            organizer.ForwardOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            camera.transform.position = cameraUserBaseLoc.transform.position;
            zoomAmount = 0;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void AutoRotate()
    {
        if(!hasStarted && children.eulerAngles.y > 1)
        {
            hasStarted = true;
        }
        children.Rotate(Vector3.up * (speed/autoRotateFractionAmount) * Time.deltaTime);
        if(children.eulerAngles.y >= 0 && children.eulerAngles.y < 1 && hasStarted)
        {
            organizer.ForwardOneModel();
            children.rotation = new Quaternion(0f, 0f, 0f, 0f);
            hasStarted = false;
        }
    }
}

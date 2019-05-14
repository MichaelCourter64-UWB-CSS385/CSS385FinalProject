using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] string horizontalName;
    [SerializeField] string verticalName;
    [SerializeField] float speed;
    [SerializeField] string mouseXName;
    [SerializeField] float horizontalSensitivity;

    Rigidbody playersRigidBody;

    // Use this for initialization
    void Start () {
        playersRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateMovement();
        UpdateRotation();
    }

    void UpdateMovement()
    {
        float horizontalValue = Input.GetAxis(horizontalName);
        float verticalValue = Input.GetAxis(verticalName);

        if (horizontalValue != 0 || verticalValue != 0)
        {
            playersRigidBody.AddForce(transform.TransformPoint(new Vector3(horizontalValue * speed * Time.deltaTime, 0, verticalValue * speed * Time.deltaTime)));
        }
    }

    void UpdateRotation()
    {
        // Adds the look input to the rotation of the camera.
        Vector3 torque = new Vector3(0, Input.GetAxis(mouseXName) * horizontalSensitivity, 0);

        playersRigidBody.AddTorque(torque * Time.deltaTime);
    }
}

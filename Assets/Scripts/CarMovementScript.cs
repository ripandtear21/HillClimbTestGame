using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D frontWheel;
    [SerializeField] private Rigidbody2D backWheel;
    [SerializeField] private float carTorque = 10f;
    float horizontalInput;

    public void OnGasButtonDown()
    {
        horizontalInput = 1;
    }

    public void OnGasButtonUp()
    {
        horizontalInput = 0;
    }

    public void OnBrakeButtonDown()
    {
        horizontalInput = -1;
    }

    public void OnBrakeButtonUp()
    {
        horizontalInput = 0;
    }

    private void FixedUpdate()
    {
        frontWheel.AddTorque(-horizontalInput * speed * Time.fixedDeltaTime);
        backWheel.AddTorque(-horizontalInput * speed * Time.fixedDeltaTime);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(-horizontalInput * speed * carTorque * Time.fixedDeltaTime);
    }
}

using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerControllerOptim : MonoBehaviour
{
    //[SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] GameObject centerOfMass;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    // UI
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    // Prevent from driving in mid air
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal1");
        forwardInput = Input.GetAxis("Vertical1");

        if (IsOnGround())
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * forwardInput);

            // UI
            speed = Mathf.RoundToInt(playerRb.linearVelocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "kph");
            rpm = Mathf.RoundToInt((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm + "rpm");
        }
        
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels )
            if (wheel.isGrounded)
                wheelsOnGround++;
        //(wheelsOnGround == 4)? return true: return false;
        if ( wheelsOnGround == 4) return true;
        else return false;
    }
}

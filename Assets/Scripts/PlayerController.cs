using UnityEngine;

// This class doesn't need a CameraSwitcherOptim.cs script
public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        // Rotate the vehicle to left and right
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * forwardInput * turnSpeed);

        // Switch between hood and main camera
        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
        
    }
}

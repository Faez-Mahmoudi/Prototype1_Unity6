using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// This class doesn't need a CameraSwitcherOptim.cs script
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private string inputID;
    
    private float horizontalInput;
    private float forwardInput;
    private GameObject finishPoint;
    public GameObject restartText;
    public GameObject cameraText;

    public TextMeshProUGUI winText;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finishPoint = GameObject.Find("Finish");

        finishPoint.SetActive(true);
        restartText.SetActive(false);
        cameraText.SetActive(true);

        if(inputID == "1")
        {
            speed += MainManager.Instance.playerOneWins;
            winText.text = "Wins: " + MainManager.Instance.playerOneWins; 
        }
        else if (inputID == "2")
        {
            speed += MainManager.Instance.playerTwoWins;
            winText.text = "Wins: " + MainManager.Instance.playerTwoWins;
        }
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
        
        // Restart Game
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Restart player position
        if(transform.position.y < -2)
        {
            if(inputID == "1")
                transform.position = new Vector3(-5, 0, -6);
            if(inputID == "2")
                transform.position = new Vector3(4, 0, -6);

            transform.rotation = new Quaternion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            if(inputID == "1")
            {
                MainManager.Instance.playerOneWins ++;
                winText.text = "Wins: " + MainManager.Instance.playerOneWins; 
            }
            else if (inputID == "2")
            {
                MainManager.Instance.playerTwoWins ++;
                winText.text = "Wins: " + MainManager.Instance.playerTwoWins;
            }
            other.gameObject.SetActive(false);
            restartText.SetActive(true);
            cameraText.SetActive(false);
        }
    }
}
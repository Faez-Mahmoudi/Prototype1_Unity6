using UnityEngine;

public class PowerupRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed); 
    }
}

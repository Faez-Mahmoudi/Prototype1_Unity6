using UnityEngine;

public class PropellerX : MonoBehaviour
{
    private float turnSpeed = 1000.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);
    }
}

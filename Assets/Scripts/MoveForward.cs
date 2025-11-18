using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy out of bounds
        if(transform.position.y < -10) Destroy(gameObject);        
    }
}

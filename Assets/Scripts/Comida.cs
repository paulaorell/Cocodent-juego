using UnityEngine;

public class Comida : MonoBehaviour
{
    public float speed = 3f; // Velocidad del alimento

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
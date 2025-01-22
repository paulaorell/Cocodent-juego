using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoMuerde : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float minY, maxY;
    private Animator animator;

    public BarraSaludDental healthManager; // Referencia al DentalHealthManager

    void Start()
    {
        animator = GetComponent<Animator>();

        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize;
        minY = -screenHeight + 1f;
        maxY = screenHeight - 1f;
    }

    void Update()
    {
        float verticalMovement = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalMovement = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalMovement = -moveSpeed * Time.deltaTime;
        }

        float newY = Mathf.Clamp(transform.position.y + verticalMovement, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food") || other.CompareTag("Candy")) 
        {
            animator.SetTrigger("Eat");
            Destroy(other.gameObject);

            if (healthManager != null)
            {
                string foodType = other.CompareTag("Candy") ? "Candy" : "Healthy";
                healthManager.ProcessFood(foodType);
            }
        }
    }
}
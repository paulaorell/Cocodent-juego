using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CocoComeCont : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float minY, maxY;
    private Animator animator;
    public BarraSaludDental healthManager;

    private GameMCandys gameMCandys;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameMCandys = GameMCandys.Instance;

        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize;
        minY = -screenHeight + 1f;
        maxY = screenHeight - 1f;

        // Buscar textos en la escena actual y asignarlos si no est�n asignados
        if (gameMCandys.foodCounterText == null)
            gameMCandys.foodCounterText = GameObject.Find("FoodCounter")?.GetComponent<TMP_Text>();

        if (gameMCandys.candyCounterText == null)
            gameMCandys.candyCounterText = GameObject.Find("CandyCounter")?.GetComponent<TMP_Text>();

        gameMCandys.UpdateFoodCounterText();
        gameMCandys.UpdateCandyCounterText();
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
        print("holaCoco");
        if (other.CompareTag("Food"))
        {
            
            animator.SetTrigger("Eat");
            Destroy(other.gameObject);
            gameMCandys.AddFood();
            

            if (healthManager != null)
            {
                healthManager.ProcessFood("Healthy");
            }
        }
        else if (other.CompareTag("Candy"))
        {
            animator.SetTrigger("Eat");
            Destroy(other.gameObject);
            gameMCandys.AddCandy();

            if (healthManager != null)
            {
                healthManager.ProcessFood("Candy");
            }
        }
    }
}

using UnityEngine;

public class PuertaTuto : MonoBehaviour
{
    [SerializeField] private GameObject primpuertaGameObject;
    private IDoor door;
    private float timer;

    private void Awake()
    {
        door = primpuertaGameObject.GetComponent<IDoor>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                door.CloseDoor();
            }
        }
      
 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            door.OpenDoor();
        }

    }
    private void OnTriggerStay2D (Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            timer = 2f;
        }
        
    }

}

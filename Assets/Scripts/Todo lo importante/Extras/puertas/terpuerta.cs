using UnityEngine;

public class terpuerta : MonoBehaviour
{
    private Animator animator3;
    [SerializeField] private GameObject segpuertaGameObject;

    private void Awake()
    {
        animator3 = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Open2")]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            animator3.SetBool("Open2", true);
        }
        Debug.Log("aaaaaaaaaaa");

    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            animator3.SetBool("Open2", false);
        }

    }

}

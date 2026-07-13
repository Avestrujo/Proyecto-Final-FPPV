using UnityEngine;

public class primpuerta : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject primpuertaGameObject;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Open")]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            animator.SetBool("Open", true);
        }
        Debug.Log("aaaaaaaaaaa");
        
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            animator.SetBool("Open", false);
        }
        
    }

}

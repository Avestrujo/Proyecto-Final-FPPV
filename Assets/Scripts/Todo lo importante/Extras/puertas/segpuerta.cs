using UnityEngine;

public class segpuerta : MonoBehaviour
{
    private Animator animator2;
    [SerializeField] private GameObject segpuertaGameObject;

    private void Awake()
    {
        animator2 = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Open1")]
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            animator2.SetBool("Open1", true);
        }
        Debug.Log("aaaaaaaaaaa");

    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            animator2.SetBool("Open1", false);
        }

    }

}

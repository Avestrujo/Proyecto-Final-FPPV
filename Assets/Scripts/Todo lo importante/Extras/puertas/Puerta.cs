using UnityEngine;

public class Puerta : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName: "Abrir")]
    public void Abrir()
    {
        animator.SetTrigger("Abrir");
    }
}

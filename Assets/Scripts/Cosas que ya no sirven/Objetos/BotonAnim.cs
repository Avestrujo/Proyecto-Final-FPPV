using UnityEngine;

public class BotonAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Presionado")]
    public void Open()
    {
        animator.SetTrigger(name: "Presionado");
    }

}

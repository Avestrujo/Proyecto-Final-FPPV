using UnityEngine;

public class PuertaAnim : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Open")]
    public void Open()
    {
        animator.SetTrigger(name:"Open");
    }
    
}

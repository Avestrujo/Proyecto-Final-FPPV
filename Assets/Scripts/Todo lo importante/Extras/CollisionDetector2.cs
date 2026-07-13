using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector2 : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string triggerScript1;
    [SerializeField] private string triggerScript2;

    [SerializeField] private UnityEvent triggerEntered1;

    [SerializeField] private UnityEvent triggerExit1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript1))
        {
            triggerEntered1?.Invoke();

        }
        if (collider.gameObject.GetComponent(triggerScript2))
        {
            triggerEntered1?.Invoke();

        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript1))
        {
            triggerExit1?.Invoke();
        }
        if (collider.gameObject.GetComponent(triggerScript2))
        {
            triggerExit1?.Invoke();
        }

    }

    private void Awake()
    {

        animator = GetComponent<Animator>();
    }
    [ContextMenu(itemName: "Pisado")]
    public void Open()
    {
        animator.SetTrigger(name: "Pisado");
    }


}
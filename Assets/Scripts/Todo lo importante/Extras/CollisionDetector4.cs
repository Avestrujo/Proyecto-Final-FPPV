using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector4 : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string triggerScript5;
    [SerializeField] private string triggerScript6;

    [SerializeField] private UnityEvent triggerEntered1;

    [SerializeField] private UnityEvent triggerExit1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript5))
        {
            triggerEntered1?.Invoke();

        }
        if (collider.gameObject.GetComponent(triggerScript6))
        {
            triggerEntered1?.Invoke();

        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript5))
        {
            triggerExit1?.Invoke();
        }
        if (collider.gameObject.GetComponent(triggerScript6))
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
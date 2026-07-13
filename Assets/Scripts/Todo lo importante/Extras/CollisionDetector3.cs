using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector3 : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string triggerScript3;
    [SerializeField] private string triggerScript4;

    [SerializeField] private UnityEvent triggerEntered1;

    [SerializeField] private UnityEvent triggerExit1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript3))
        {
            triggerEntered1?.Invoke();

        }
        if (collider.gameObject.GetComponent(triggerScript4))
        {
            triggerEntered1?.Invoke();

        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent(triggerScript3))
        {
            triggerExit1?.Invoke();
        }
        if (collider.gameObject.GetComponent(triggerScript4))
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
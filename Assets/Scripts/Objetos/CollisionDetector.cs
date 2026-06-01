using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string colliderScript;
    [SerializeField] private string colliderScript2;

    [SerializeField] private UnityEvent CollisionEntered;

    [SerializeField] private UnityEvent CollisionExit;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent(colliderScript))
        {
            CollisionEntered?.Invoke();

        }
        if (collider.gameObject.GetComponent(colliderScript2))
        {
            CollisionEntered?.Invoke();

        }

    }
    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent(colliderScript))
        {
            CollisionExit?.Invoke();
        }
        if (collider.gameObject.GetComponent(colliderScript2))
        {
            CollisionExit?.Invoke();
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

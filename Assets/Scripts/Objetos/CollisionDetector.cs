using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string colliderScript;
    
    [SerializeField] private UnityEvent CollisionEntered;

    [SerializeField] private UnityEvent CollisionExit;
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent(colliderScript))
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

    }
}

using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string colliderScript;
    
    [SerializeField] private UnityEvent CollisionEntered;

    [SerializeField] private UnityEvent CollisionExit;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(colliderScript))
        {
            CollisionEntered?.Invoke();
        }
            
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(colliderScript))
        {
            CollisionExit?.Invoke();
        }

    }
}

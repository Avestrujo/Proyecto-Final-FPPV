using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string triggerscript;

    [SerializeField] private UnityEvent triggerentered;

    [SerializeField] private UnityEvent triggerexit;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(triggerscript))
        {
            triggerentered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent(triggerscript))
        {
            triggerexit?.Invoke();
        }
    }
    //a

}

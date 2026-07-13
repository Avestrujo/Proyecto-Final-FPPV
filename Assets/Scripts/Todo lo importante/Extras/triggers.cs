using UnityEngine;

public class triggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggereado");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("triggereando");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("destriggereado");
    }
}

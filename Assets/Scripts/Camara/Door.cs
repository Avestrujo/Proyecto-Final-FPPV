using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform salaAnterior;
    [SerializeField] private Transform salaPosterior;
    [SerializeField] private CamaraControlador cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.SiguienteSala(salaPosterior);
            }
            else
            {
                cam.SiguienteSala(salaAnterior);
            }
        }
    }

}

using UnityEngine;

public class CamaraControlador : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocidad = Vector3.zero;
    
    void Update()
    { //Movimiento de la camara
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), 
            ref velocidad, speed);

    }

    public void SiguienteSala(Transform NuevaSala)
    {
        currentPosX = NuevaSala.position.x;
    }
}

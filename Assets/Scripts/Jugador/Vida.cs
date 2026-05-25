using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private float vidaInicial;
    private float vidaActual;

    private void Awake()
    {
        vidaActual = vidaInicial;
    }

    public void RecibirDaño(float daño)
    {
        vidaActual = Mathf.Clamp(vidaActual - daño, 0, vidaInicial);
        if (vidaActual > 0)
        {
            
        }
        else
        {
            print("muelto");
        }
    }







}

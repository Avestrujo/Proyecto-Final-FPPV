using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float VelocidadMov = 5f;
    private Rigidbody2D rb;
    private Vector2 InputMov;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb.linearVelocity = InputMov * VelocidadMov;
    }

    public void Movimiento (InputAction.CallbackContext contexto) //InputAction.CallbackContext se usa para conseguir la informacion de la accion ejecutada
    {
        InputMov = contexto.ReadValue<Vector2>();
    }
}

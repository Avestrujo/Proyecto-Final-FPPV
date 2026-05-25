using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovementCorrecto : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float MovimientoHorizontal = 0f;
    [SerializeField] private float VelocidadMovimiento;
    [Range(0, 0.5f)][SerializeField] private float SuavizadoMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * VelocidadMovimiento;
    }
    private void FixedUpdate()
    {
        Mover(MovimientoHorizontal * Time.fixedDeltaTime);
        
    }
    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, SuavizadoMovimiento);

        if (mover > 0 && !mirandoDerecha)
            Girar();
        else if (mover < 0 && mirandoDerecha)
            Girar();

    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}

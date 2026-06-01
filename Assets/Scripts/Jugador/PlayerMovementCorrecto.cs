using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementCorrecto : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float MovimientoHorizontal = 0f;
    [SerializeField] private float VelocidadMovimiento;
    [Range(0, 0.5f)][SerializeField] private float SuavizadoMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private LayerMask Suelo;
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }
    private void Update()
    { //Movimiento horizontal y vertical
        MovimientoHorizontal = Input.GetAxisRaw("Horizontal") * VelocidadMovimiento;
        
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }
    private void FixedUpdate()
    { //Comprobacion de si el personaje esta en el suelo
        enSuelo = Physics2D.OverlapBox(ControladorSuelo.position, dimensionesCaja, 0f, Suelo);

        Mover(MovimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }
    private void Mover(float mover, bool saltar)
    { //Suavizado del movimiento y giro del sprite
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, SuavizadoMovimiento);

        if (mover > 0 && !mirandoDerecha)
            Girar();
        else if (mover < 0 && mirandoDerecha)
            Girar();

        if(enSuelo && saltar)
        { //Comprobacion de si el personaje esta en el suelo2
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, FuerzaSalto));
        
        
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ControladorSuelo.position, dimensionesCaja);
    }
}

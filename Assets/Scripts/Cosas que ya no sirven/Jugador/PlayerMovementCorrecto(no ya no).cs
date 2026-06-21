using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementIncorrecto : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public GameObject BulletPrefab;
    public float Health = 1f;

    private float MovimientoHorizontal = 0f;
    [SerializeField] private float VelocidadMovimiento;
    [Range(0, 0.5f)][SerializeField] private float SuavizadoMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private LayerMask Suelo; //capa con la que interactua el personaje para comprobar si esta en el suelo
    [SerializeField] private Transform ControladorSuelo; //objeto que se situa en la parte inferior del personaje para comprobar si esta en el suelo
    [SerializeField] private Vector3 dimensionesCaja; //dimensiones de la caja
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
        Shoot();
    }
    private void FixedUpdate()
    { //Comprobacion de si el personaje esta en el suelo
        enSuelo = Physics2D.OverlapBox(ControladorSuelo.position, dimensionesCaja, 0f, Suelo); //overlapbox es un collider invisible que chequea colisiones en su area

        Mover(MovimientoHorizontal * Time.fixedDeltaTime, salto); //Movimiento independiente del framerate

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

        if (enSuelo && saltar)
        { //Comprobacion de si el personaje esta en el suelo2
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, FuerzaSalto));
        }
    }
    private void Girar()
    { //Metodo para girar el sprite
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    { //gizmos para ver y comprobar el area de comprobacion del suelo
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ControladorSuelo.position, dimensionesCaja);
    }
    public void Shoot()
    {
        //Input.mousePosition
        //Camera.main.ScreenToWorldPoint()
        //Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
        direction.z = 0;
        direction.Normalize();
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = direction;
        }

    }
}

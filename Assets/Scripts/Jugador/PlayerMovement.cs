using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeed; 
    private Rigidbody2D body;
    [SerializeField] private float VerticalSpeed;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");

        //movimiento del personaje (horizontal y vertical)

        body.linearVelocity = new Vector2((horizontalInput) * HorizontalSpeed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, VerticalSpeed);
        }

        //direccion del personaje
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(3f, 3f, 3f);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-3f, 3f, 3f);

    }





}
    

    
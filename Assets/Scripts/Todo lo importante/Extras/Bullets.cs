using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float TimeAlive = 3f;
    void Start()
    {
        Destroy(gameObject, TimeAlive);

    }
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Golpe");
        if (collision.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemigo>().TakeDamage(1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.tag != "Player")
            Destroy(gameObject);
    }
}
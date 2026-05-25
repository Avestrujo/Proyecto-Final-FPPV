using System.Runtime.CompilerServices;
using UnityEngine;

public class DañoAmbiental : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Vida>().RecibirDaño(Damage);
    }
}

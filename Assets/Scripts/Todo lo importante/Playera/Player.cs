using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
    public float Speed;

    public float MaxTime = 10f;

    public GameObject BulletPrefab;

    void Start()
    {
        
    }

    
    void Update()
    {
        
        MovementPlayer();
        Shoot();
    }

    public void MovementPlayer()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();
        if(dir != Vector3.zero)
            transform.position += dir * Speed * Time.deltaTime;


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

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Target;
    public float Speed;
    public float radiusMovement;
    public float radiusAttack;
    public float AttackTime;
    public float MaxAttackTime = 2f;
    public bool IsAbleToAttack;
    public float damage = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        followTarget();
        AttackTimer();
        
    }

    public void followTarget()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;

        Vector3 direction = (targetPos - myPos).normalized;
        
        if(Vector3.Distance(targetPos, myPos) < radiusMovement)
        {
            if(Vector3.Distance(targetPos, myPos) < radiusAttack)
            {
                if(IsAbleToAttack)
                {
                    //GetComponent
                    Debug.Log("Atacado");
                    Target.GetComponent<PlayerMovementCorrecto>().Health -= damage;
                    IsAbleToAttack = false;
                    AttackTimer();
                }

            }
            else
            {
                transform.position += direction * Speed * Time.deltaTime;
            }

        }
    }

    public void AttackTimer()
    {
        AttackTime += Time.deltaTime;
        if (AttackTime >= MaxAttackTime) 
        {
            IsAbleToAttack = true;
            //ataque
            AttackTime = 0;
        }

    }
}

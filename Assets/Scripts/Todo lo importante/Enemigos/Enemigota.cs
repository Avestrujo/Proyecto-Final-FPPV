using UnityEngine;
public enum EnemyEnum
{
    None,
    Idle,
    Chase,
    Attack
}
public class Enemigota : MonoBehaviour
{
    public EnemyEnum state = EnemyEnum.Idle;

    public GameObject Target;
    public float Speed;
    public float DetectionRadius;
    public float radiusAttack;
    public float AttackTime;
    public float MaxAttackTime = 2f;
    public bool IsAbleToAttack;

    void Start()
    {

    }

    void Update()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;
        switch (state)
        {
            case EnemyEnum.None:
                break;
            case EnemyEnum.Idle:
                {
                    if (Vector3.Distance(targetPos, myPos) < DetectionRadius)
                        state = EnemyEnum.Chase;
                }
                break;
            case EnemyEnum.Chase:
                {
                    if (Vector3.Distance(targetPos, myPos) > DetectionRadius)
                        state = EnemyEnum.Idle;

                    if (Vector3.Distance(targetPos, myPos) < radiusAttack)
                        state = EnemyEnum.Attack;
                }
                break;
            case EnemyEnum.Attack:
                {
                    if (Vector3.Distance(targetPos, myPos) > radiusAttack)
                        state = EnemyEnum.Chase;
                }
                break;
            default:
                break;
        }
        followTarget();
        AttackTimer();
        
    }
    public void followTarget()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;

        Vector3 direction = (targetPos - myPos).normalized;

        if (Vector3.Distance(targetPos, myPos) > DetectionRadius)
        {
            if (Vector3.Distance(targetPos, myPos) < radiusAttack)
            {
                if (IsAbleToAttack)
                {
                    
                    Debug.Log("Atacado");
                    
                    AttackTimer();
                    IsAbleToAttack = false;
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


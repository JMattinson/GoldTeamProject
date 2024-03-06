using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyBipedBehavior : EnemyBase

{
    [Header("Entity Management")]
    public UnityEvent dieEvent, attackEvent,noAttackEvent,damageEvent, EnableEvent,RespawnEvent;
    public FloatData bipedMaxHp, EnCurrentHp,enpassHP,deadPassHP;
    public IntData playerCurrentDamage,DangerLevel;
    public UnityAction<ImageBehavior> UpdateImage;


    [Header("Navigation")]
    public Transform playerPos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;


    public float sightRange, attackRange;
    public bool PlayerInSight, PlayerInAttack;
    

    public override void Start()
    {

        EnCurrentHp = ScriptableObject.CreateInstance<FloatData>();
        DangerLevel = ScriptableObject.CreateInstance<IntData>();
        DangerLevel.value = 1;
        EnCurrentHp.value = bipedMaxHp.value;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
        PlayerInSight = true;
        
    }


    public override void Wander()
    {
        
    }

    public override void SearchWalkPoint()
    {
    }

    public override void Hunt()
    {
        agent.SetDestination(playerPos.position);
    }

    public override void Attack()
    {
        agent.SetDestination(transform.position);
        attackEvent.Invoke();
    }

    public override void TakeDamage()
    {
        PlayerInSight = true;
        EnCurrentHp.value -= (playerCurrentDamage.value/(DangerLevel.value));
        enpassHP.value = EnCurrentHp.value;
        damageEvent.Invoke();
        if (EnCurrentHp.value <= 0)
        {
            Die();
        }
    }

    public override void Regen()
    {
        if (EnCurrentHp.value >= bipedMaxHp.value)
        {
            Respawn();
        }
        EnCurrentHp.value += 2;
        deadPassHP.value = EnCurrentHp.value;
    }

    public override void Die()
    {
        dieEvent.Invoke();
    }

    public override void Respawn()
    {
        RespawnEvent.Invoke();
        DangerLevel.value++;
    }


    public void Think()
    {
        
        PlayerInAttack = Physics.CheckSphere(transform.position, attackRange,Player);
        if (PlayerInSight)
        {
            noAttackEvent.Invoke();
            Hunt();
            
        }
        if (PlayerInAttack)
        {
            attackEvent.Invoke();
            Hunt();
        }

    }

    public void OnEnable()
    {
        EnCurrentHp.value = bipedMaxHp.value;
        EnableEvent.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}

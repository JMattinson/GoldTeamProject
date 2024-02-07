using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class HunterEneBeh : MonoBehaviour
{
    //this is just a butchered/edited version of jaden's EnemyBipedBehavior code
    
     [Header("Entity Management")]
    public UnityEvent deathEv, attackEv, dmgEv;
    public float MaxHp, CurrentHp;
    public UnityAction<ImageBehavior> UpdateImage;


    [Header("Navigation")]
    public Transform playerPos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;
    
    public void Start()
    {
        CurrentHp = MaxHp;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
    }
    public void Hunt()
    {
        //if you are not within attack range, then move towards player
        if (playerPos)//if your close enough to attack then stop moving and hit it
        {
            // use an animator/animation to make the weapon swing and have some down time
            agent.SetDestination(transform.position);
            attackEv.Invoke();
        }
        else
        {
            agent.SetDestination(playerPos.position);
        }
    }

    public void TakeDamage(float dmg)
    {
        // can add complex code here to change for atk dmg vs def etc.
        CurrentHp -= dmg;
        dmgEv.Invoke();//this calls the health bar update
        if (CurrentHp <= 0)
        {
            deathEv.Invoke();
            Destroy(this.gameObject);
        }
    }

}

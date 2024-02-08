using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class HunterEneBeh : MonoBehaviour
{
    //this is just a butchered/edited version of jaden's EnemyBipedBehavior code
    
    public UnityEvent deathEv, attackEv, dmgEv;
    public float MaxHp, CurrentHp, AtkRng, MvSpeed;
    //public UnityAction<ImageBehavior> UpdateImage;
    
    private Transform playerPos;
    private NavMeshAgent agent;
    
    public void Start()
    {
        CurrentHp = MaxHp;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
    }
    public void Hunt()//gets called when player enters the hunt range collison
    {
        //if your close enough to attack then stop moving and hit it
        if ((Vector3.Distance(gameObject.transform.position,playerPos.position))<=AtkRng)
        {
            // use an animator/animation to make the weapon swing and have some down time
            agent.SetDestination(transform.position);
            agent.speed = 0;
            attackEv.Invoke();
        }
        else//if you are not within attack range, then move towards player
        {
            agent.speed = MvSpeed;
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

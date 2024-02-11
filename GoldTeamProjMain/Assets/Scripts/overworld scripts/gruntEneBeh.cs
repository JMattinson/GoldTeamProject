using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class gruntEneBeh : MonoBehaviour
{
    public float maxhp, CurrentHp, atkRng;
    public UnityEvent dmgEv, deathEv, atkEv;
    [Tooltip("check this if this enemy is suppose to patrol an area")]
    public bool PatrolingEnemy;
    [Tooltip("locations in order for patrol route")]
    public Vector3[] points;

    private NavMeshAgent agent;
    private bool currentlyPatroling;
    private WaitForSeconds delay;
    private Transform playerPos,startLoc;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = maxhp;
        agent=GetComponent<NavMeshAgent>();
        delay = new WaitForSeconds(1f);
        playerPos = GameObject.Find("Player").transform;
        startLoc = gameObject.transform;//patroling enemy needs to be placed on 1st patrol point
        if (PatrolingEnemy==true)
        {
            currentlyPatroling = true;
            StartCoroutine(patrolLoop());
        }
    }

    public void attack()
    {
        agent.SetDestination(playerPos.position);
        if (PatrolingEnemy==true)
        {
            currentlyPatroling = false;
            StopCoroutine(patrolLoop());
        }

        StartCoroutine(followPlr());
    }

    public void goHome()
    {
        StopCoroutine(followPlr());
        agent.SetDestination(startLoc.position);
        if (PatrolingEnemy==true)
        {
            currentlyPatroling = true;
            StartCoroutine(patrolLoop());
        }
    }
    
    public void TakeDamage(playerInvent whereDmg)//call this from a trigger event scrpt
    {
        // can add complex code here to change for atk dmg vs def etc.
        CurrentHp -= whereDmg.wepDmg;
        dmgEv.Invoke();//this calls the health bar update
        if (CurrentHp <= 0)
        {
            deathEv.Invoke();
            Destroy(this.gameObject);
        }
    }

    private IEnumerator patrolLoop()
    {
        int looping = 0;
        while (currentlyPatroling==true)
        {
            if (agent.hasPath==false)
            {
                agent.SetDestination(points[looping]);
                looping++;
                if (looping>points.Length)
                {   //reset at the end of the list
                    looping = 0;
                }
            }
            yield return delay;
        }
        yield return delay;
    }
    
    private IEnumerator followPlr()//triggered by camp
    {
        while (Vector3.Distance(transform.position,playerPos.position)>0)//if you are not on top of player
        {
            agent.SetDestination(playerPos.position);
            if (agent.remainingDistance<=atkRng)
            {   //if you're close enough to attack then stop moving and hit it
                agent.isStopped = true;
                // use an animator/animation to make the weapon swing and have some down time
                atkEv.Invoke();
            }
            yield return delay;
        }
    }
}

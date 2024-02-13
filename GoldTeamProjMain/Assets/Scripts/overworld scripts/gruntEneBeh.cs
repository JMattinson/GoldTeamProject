using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class gruntEneBeh : MonoBehaviour
{
    public float atkRng;
    public GameObject parent;
    
    [Tooltip("check this if this enemy is suppose to patrol an area")]
    public bool PatrolingEnemy;
    
    [Tooltip("locations in order for patrol route")]
    public List<Vector3> points;

    [Tooltip("pls ignore it needs to be public for math")]
    public List<Vector3> editPoints;
    
    public UnityEvent dmgEv, deathEv, atkEv;

    private NavMeshAgent agent;
    private bool currentlyPatroling;
    private WaitForSeconds delay;
    private Transform playerPos,startLoc;
    private int looping;
    
    // Start is called before the first frame update
    void Start()
    {
        editPoints.Clear();
        agent=GetComponent<NavMeshAgent>();
        delay = new WaitForSeconds(1f);
        playerPos = GameObject.Find("Player").transform;
        startLoc = gameObject.transform;//patroling enemy needs to be placed on 1st patrol point
        
        if (PatrolingEnemy==true)
        {
            looping = 0;
            foreach (var item in points)
            {//nav mesh agents dont do local vs world coords, this math will do that for us
                editPoints.Add(new Vector3((points[looping].x+parent.transform.position.x),0,(points[looping].z+parent.transform.position.z)));
                looping++;
            }
            currentlyPatroling = true;
            StartCoroutine(patrolLoop());
        }
    }

    public void attack()//add code here so if they are close enough they will take a swipe
    {
        agent.SetDestination(playerPos.position);
        StopCoroutine(patrolLoop());
        if (PatrolingEnemy==true)
        {
            currentlyPatroling = false;
        }
    }

    public void goHome()
    {
        agent.SetDestination(startLoc.position);
        if (PatrolingEnemy==true)
        {
            currentlyPatroling = true;
            StartCoroutine(patrolLoop());
        }
    }
    


    private IEnumerator patrolLoop()
    {
        looping = 0;
        while (currentlyPatroling==true)
        {
            if (agent.hasPath==false)
            {
                agent.SetDestination(editPoints[looping]);
                looping++;
                if (looping>=points.Count)
                {   //reset at the end of the list
                    looping = 0;
                }
            }
            yield return delay;
        }
        yield return delay;
    }
    
}

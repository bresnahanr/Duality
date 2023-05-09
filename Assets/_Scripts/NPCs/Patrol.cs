using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{

    public float speed;
    public NavMeshAgent agent;

    private float waitTime;
    public float startWaitTime;

    private Vector3 moveSpot;
    public float patrolRadius;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot = RandomPatrolPoint(patrolRadius);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpot) < 0.1f)
		{
            if (waitTime <= 0)
			{
                moveSpot = RandomPatrolPoint(patrolRadius);
                waitTime = startWaitTime;
            }

            else
                waitTime -= Time.deltaTime;
		}

    }

    Vector3 RandomPatrolPoint(float range)
	{
        Vector3 pt = transform.position;
        return new Vector3(
            Random.Range(pt.x - range, pt.x + range),
            transform.position.y,
            Random.Range(pt.z - range, pt.z + range));

       
	}
}

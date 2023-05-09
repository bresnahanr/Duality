using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooseMovementController : MonoBehaviour
{
    public CharacterController controller;
    public NavMeshAgent agent;
    public GooseAttributes attributes;

	private void Start()
	{
        agent.speed = attributes.movementSpeed;
	}

	// Update is called once per frame
	void Update()
    {
		if (!GameVariables.isGooseMode)
		{
            agent.enabled = false;
            return;
		}

        agent.enabled = true;
        Vector3 targetDirection = GetHighValueTargetPosition();
        agent.SetDestination(targetDirection);

    }

    private void OnEnable()
	{
        TimeManager.OnHourChanged += TimeCheck;
	}

    private void OnDisable()
    {
        TimeManager.OnHourChanged -= TimeCheck;
    }

    private void TimeCheck()
	{
        if(TimeManager.Hour == GameVariables.nightModeHour)
		{
            agent.speed = attributes.movementSpeed;
            GameVariables.isGooseMode = true;
		}
        if(TimeManager.Hour == GameVariables.dayModeHour)
		{
            GameVariables.isGooseMode = false;
		}
	}

    public Vector3 GetHighValueTargetPosition()
	{
        float closest = Mathf.Infinity;
        Vector3 destination = new Vector3();

        foreach(Townsfolk victim in TownsfolkManager.townsfolkList)
		{
            float dist = Vector3.Distance(victim.transform.position, transform.position);
            if (dist < closest)
			{
                closest = dist;
                destination = victim.transform.position;
            }

		}
        return destination;
	}
}

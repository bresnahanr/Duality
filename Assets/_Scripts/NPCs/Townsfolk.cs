using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Townsfolk : MonoBehaviour
{
	[Range(0f, 100f)] public float hitPoints = 25;
	[HideInInspector] public float healthPerTick;
	public TownsfolkType type;

	private float timeToHealTick = 1;
	private float timer;
	private Renderer myRenderer;

	private void OnEnable()
	{
		TownsfolkManager.townsfolkList.Add(this);
	}

	private void OnDisable()
	{
		TownsfolkManager.townsfolkList.Remove(this);
	}

	void Start()
	{
		timer = timeToHealTick;
		myRenderer = GetComponent<Renderer>();
		UpdateWellness();

	}

	private void OnTriggerStay(Collider other)
	{
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			if(GameVariables.isGooseMode)
				healthPerTick = other.GetComponent<GooseAttributes>().tickStrength * -1f; //Hurting is healing in reverse
			else
				healthPerTick = other.GetComponent<PlayerAttributes>().tickStrength;

			hitPoints = Mathf.Clamp(hitPoints + healthPerTick, 0, type.hitPointsMax); //Adjusts value to between 0 and max hits
			UpdateWellness();
			timer = timeToHealTick;
			if (hitPoints == 0)
			{
				Destroy(gameObject);
				//Destroy(gameObject, 5); //destroy with delay. useful to show death animation
			}
				
		}

	}

	private void UpdateWellness()
	{
		//isHealthy = (hitPoints >= 75);

		if (hitPoints < 25)
			myRenderer.material.color = GameVariables.Fatal;
		else if (hitPoints < 50)
			myRenderer.material.color = GameVariables.Injured;
		else if (hitPoints < 75)
			myRenderer.material.color = GameVariables.Okay;
		else if (hitPoints < type.hitPointsMax)
			myRenderer.material.color = GameVariables.Decent;
		else if (hitPoints == type.hitPointsMax)
			myRenderer.material.color = GameVariables.Full;

	}
}

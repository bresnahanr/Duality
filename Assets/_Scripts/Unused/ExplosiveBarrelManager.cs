using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelManager : MonoBehaviour
{
    public static List<ExplosiveBarrel> allTheBarrels = new List<ExplosiveBarrel>();

	private void OnDrawGizmos()
	{
		foreach(ExplosiveBarrel barrel in allTheBarrels)
		{
			Gizmos.DrawLine(transform.position, barrel.transform.position);
		}

	}
}

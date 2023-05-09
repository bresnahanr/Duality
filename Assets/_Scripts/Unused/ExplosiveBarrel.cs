using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
	[Range( 1f, 8f )]
    public float radius = 1f;

    public float damage = 10f;

    public Color color = Color.red;

	private void OnEnable() => ExplosiveBarrelManager.allTheBarrels.Add(this);

	private void OnDisable() => ExplosiveBarrelManager.allTheBarrels.Remove(this);

	void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, radius);
}

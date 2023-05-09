using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TownsfolkType : ScriptableObject
{
	[Range(0f, 100f)] public float hitPoints = 25;
	[Range(0f, 5f)] public float speed = 2;

	public float hitPointsMax = 100;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TownsfolkManager : MonoBehaviour
{
	public static List<Townsfolk> townsfolkList = new List<Townsfolk>();

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		foreach (Townsfolk townsfolk in townsfolkList)
		{
			Vector3 managerPos = transform.position;
			Vector3 townsfolkPos = townsfolk.transform.position;
			float halfHeight = (managerPos.y - townsfolkPos.y) * 0.5f;
			Vector3 offset = Vector3.up * halfHeight;

			Handles.DrawBezier(transform.position, 
				townsfolk.transform.position, 
				managerPos - offset, 
				townsfolkPos + offset, 
				Color.white, 
				EditorGUIUtility.whiteTexture, 
				1f);
			//Handles.DrawAAPolyLine(transform.position, townsfolk.transform.position);
			//Gizmos.DrawLine(transform.position, townsfolk.transform.position);
		}
	}
	#endif

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables
{
	public static int nightModeHour = 0;
	public static int dayModeHour = 6;
	public static bool isGooseMode;

	public static Color Full = Color.blue;
	public static Color Decent = Color.green;
	public static Color Okay = Color.yellow;
	public static Color Injured = new Color(255f, 165f, 0f, 1f);
	public static Color Fatal = Color.red;
}

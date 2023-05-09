using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff : ScriptableBuff
{
	public float SpeedIncrease;

	public override TimedBuff InitTimedBuff(Attributes attr)
	{
		return new TimedSpeedBuff( this, attr);
	}

}

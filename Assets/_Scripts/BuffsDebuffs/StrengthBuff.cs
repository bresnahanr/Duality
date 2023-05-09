using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/StrengthBuff")]
public class StrengthBuff : ScriptableBuff
{
    public float StrengthIncrease;

	public override TimedBuff InitTimedBuff(Attributes attr)
	{
		return new TimedStrengthBuff(this, attr);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStrengthBuff : TimedBuff
{
    private readonly Attributes _strengthComponent;

	public TimedStrengthBuff(ScriptableBuff buff, Attributes attr) : base(buff, attr)
	{
		_strengthComponent = attr;
	}

	protected override void ApplyEffect()
	{
		StrengthBuff strengthBuff = (StrengthBuff)buff;
		_strengthComponent.tickStrength += strengthBuff.StrengthIncrease;
	}

	public override void End()
	{
		StrengthBuff strengthBuff = (StrengthBuff)buff;
		_strengthComponent.tickStrength -= strengthBuff.StrengthIncrease * effectStacks;
		effectStacks = 0;
	}
}

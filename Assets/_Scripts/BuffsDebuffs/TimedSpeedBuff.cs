using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
	private readonly Attributes _movementComponent;
	public TimedSpeedBuff(ScriptableBuff buff, Attributes attr) : base(buff, attr)
	{
		_movementComponent = attr;
	}

	protected override void ApplyEffect()
	{
		SpeedBuff speedBuff = (SpeedBuff)buff;
		_movementComponent.movementSpeed += speedBuff.SpeedIncrease;
	}

	public override void End()
	{
		SpeedBuff speedBuff = (SpeedBuff)buff;
		_movementComponent.movementSpeed -= speedBuff.SpeedIncrease * effectStacks;
		effectStacks = 0;
	}
}

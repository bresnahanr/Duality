using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedBuff
{
    protected float duration;
    protected int effectStacks;
    public ScriptableBuff buff { get; }
    protected readonly Attributes attr;
    public bool IsFinished;

    public TimedBuff(ScriptableBuff scriptableBuff, Attributes attributes)
	{
        buff = scriptableBuff;
        attr = attributes;
	}

    public void Tick(float delta)
	{
        duration -= delta;
        if (duration <= 0 && !buff.isPermanent)
		{
            End();
            IsFinished = true;
		}
	}

    // Activates buff or extends duration if ScriptableBuff has IsDurationStacked or IsEffectStacked set to true
    public void Activate()
	{
		if (buff.isEffectStacked || duration <= 0)
		{
            ApplyEffect();
            effectStacks++;
		}
        if(buff.isDurationStacked || duration <= 0)
		{
            duration += buff.duration;
		}

	}

    protected abstract void ApplyEffect();
    public abstract void End();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableBuff : ScriptableObject
{
    public string displayString;

    public Sprite icon;

    public float duration;

    public bool isDurationStacked;

    public bool isEffectStacked;

    public bool isPermanent;

    public int tier;

    public abstract TimedBuff InitTimedBuff(Attributes attr);
}

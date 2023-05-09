using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    private readonly Dictionary<ScriptableBuff, TimedBuff> timedBuffs = new Dictionary<ScriptableBuff, TimedBuff>();

    public float movementSpeed;
    public float tickStrength;
    

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
            return;

        foreach(var timedBuff in timedBuffs.Values.ToList())
		{
            timedBuff.Tick(Time.deltaTime);

            if (timedBuff.IsFinished)
                timedBuffs.Remove(timedBuff.buff);

		}
    }

    public void AddTimedBuff(TimedBuff timedBuff)
	{
		if (timedBuffs.ContainsKey(timedBuff.buff))
		{
            timedBuffs[timedBuff.buff].Activate();
		} else
		{
            timedBuffs.Add(timedBuff.buff, timedBuff);
            timedBuff.Activate();

        }
	}

}

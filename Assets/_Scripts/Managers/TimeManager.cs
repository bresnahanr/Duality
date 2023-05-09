using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Day { get; private set; }

    [SerializeField]
    [Tooltip("Speed at which one in game minute passes in seconds")]
    private float minuteToRealTime = 0.5f;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 6;
        Day = 0;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
		{
            Minute++;

            if(Minute >= 60)
			{
                Hour++;
                Minute = 0;

                if(Hour >= 24)
				{
                    Day++;
                    Hour = 0;
				}

                OnHourChanged?.Invoke();

			}

            OnMinuteChanged?.Invoke();

            timer = minuteToRealTime;
		}
    }
}

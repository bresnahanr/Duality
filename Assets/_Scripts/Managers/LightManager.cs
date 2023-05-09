using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject daylight;

    void Start()
    {
        daylight.transform.Rotate(0, 0, -90);
    }

	private void OnEnable()
	{
        TimeManager.OnMinuteChanged += UpdateTime;

	}

	private void OnDisable()
	{
		TimeManager.OnMinuteChanged -= UpdateTime;
	}

	private void UpdateTime()
	{
		daylight.transform.Rotate(0, 0, 0.25f);
	}
}

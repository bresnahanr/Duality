using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{

    public TMP_Text timeText;
	public TMP_Text dayCount;

	private void OnEnable()
	{
		TimeManager.OnMinuteChanged += UpdateTime;
		TimeManager.OnHourChanged += UpdateTime;
	}

	private void OnDisable()
	{
		TimeManager.OnMinuteChanged -= UpdateTime;
		TimeManager.OnHourChanged -= UpdateTime;
	}

	private void UpdateTime()
	{
		timeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
		dayCount.text = $"Day: {TimeManager.Day}";
	}
}

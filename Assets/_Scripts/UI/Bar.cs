using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxValue { get; private set; }
	public float value { get; private set; }

	[SerializeField]
	private Townsfolk thisObject;

	[SerializeField]
	private RectTransform _topBar;

	[SerializeField]
	private RectTransform _bottomBar;

	[SerializeField]
	private float _animationSpeed = 10f;

	private float _fullWidth;
	private float TargetWidth => value * _fullWidth / maxValue;

	private Coroutine _adjustBarWidthCoroutine;

	private void Start()
	{
		
		maxValue = thisObject.type.hitPointsMax;
		_fullWidth = _topBar.rect.width;
	}

	public void Change()
	{
		value = thisObject.hitPoints;
		if (_adjustBarWidthCoroutine != null)
		{
			StopCoroutine(_adjustBarWidthCoroutine);
		}
		_adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(thisObject.healthPerTick));

	}

	private IEnumerator AdjustBarWidth(float amount)
	{
		var suddenChangeBar = amount >= 0 ? _bottomBar : _topBar;
		var slowChangeBar = amount >= 0 ? _topBar : _bottomBar;

		suddenChangeBar.SetWidth(TargetWidth);

		while (Mathf.Abs(suddenChangeBar.rect.width - slowChangeBar.rect.width) > 1f)
		{
			slowChangeBar.SetWidth(
				Mathf.Lerp(slowChangeBar.rect.width, TargetWidth, Time.deltaTime * _animationSpeed));
			yield return null;
		}
		slowChangeBar.SetWidth(TargetWidth);
	}

	private void Update()
	{
		Change();

		//Change rotation to billboard plane
		transform.rotation = Camera.main.transform.rotation;
	}

}

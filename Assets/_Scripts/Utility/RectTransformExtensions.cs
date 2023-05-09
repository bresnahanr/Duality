using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public static class RectTransformExtensions
	{

		public static void SetWidth(this RectTransform t, float width)
		{
			t.sizeDelta = new Vector2(width, t.rect.height);
		}
	}
}
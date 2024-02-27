using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField] List<ShopItem> items;

	public void ShowShop()
	{
		gameObject.SetActive(true);
		EnableGraphics();
	}

	private void EnableGraphics()
	{
		foreach (Graphic graphic in GetComponentsInChildren<Graphic>()) 
		{
			graphic.enabled = true;
		}
	}

	public void HideGraphics()
	{
		foreach (Graphic graphic in GetComponentsInChildren<Graphic>())
		{
			graphic.enabled = false;
		}
	}
}

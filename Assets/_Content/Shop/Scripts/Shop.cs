using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField] List<ShopItem> items;
	[SerializeField] Button buyButton;
	[SerializeField] Button cancelButton;

	private ShopItem selectedItem;

	public event Action OnShopClose;

	private void Awake()
	{
		buyButton.interactable = false;
		RefreshItems();
	}

	private void Start()
	{
		buyButton.onClick.AddListener(BuyItem);
		cancelButton.onClick.AddListener(CloseShop);
	}

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

	public void _ToggleSelectedItem(ShopItem item)
	{
		if(item == selectedItem)
		{
			selectedItem = null;

			buyButton.interactable = false;
			return;
		}

		selectedItem = item;

		buyButton.interactable = true;
	}

	private void RefreshItems()
	{
		foreach(ShopItem item in items)
		{
			if(item.IsSold)
			{
				item.Disable();
			}
		}
	}

	private void BuyItem()
	{
		Item item = selectedItem.SellItem();
		PlayerController.Instance.AddOwnedItem(item);

		RefreshItems();
	}

	private void CloseShop()
	{
		HideGraphics();
		gameObject.SetActive(false);

		OnShopClose();
	}
}

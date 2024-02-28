using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField] List<ShopItem> items;
	[SerializeField] Button buyButton;
	[SerializeField] Button sellButton;
	[SerializeField] Button cancelButton;

	[SerializeField] RectTransform buyPanel;
	[SerializeField] RectTransform sellPanel;

	[SerializeField] Button buyModeButton;
	[SerializeField] Button sellModeButton;

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
		sellButton.onClick.AddListener(SellItem);
		cancelButton.onClick.AddListener(CloseShop);

		buyModeButton.onClick.AddListener(SwitchToBuyMode);
		sellModeButton.onClick.AddListener(SwitchToSellMode);

		SwitchToBuyMode();
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
		foreach(ShopItem shopItem in items)
		{
			if(shopItem.item.Value > Player.Instance.GetMoneyOwned())
			{
				shopItem.Disable();
			}

			if (shopItem.IsSold)
			{
				shopItem.gameObject.SetActive(false);
			}
		}
	}

	private void BuyItem()
	{
		Item item = selectedItem.MakeSale();
		Player.Instance.AddOwnedItem(item);

		Player.Instance.DeductMoney(item.Value);

		GameUI.Instance.UpdateMoneyText(Player.Instance.GetMoneyOwned());
		GameUI.Instance.AddItemToInventory(item);

		RefreshItems();
	}

	private void SellItem()
	{
		Item item = selectedItem.MakeSale();
		Player.Instance.RemoveOwnedItem(item);
		Player.Instance.UnequipItem(item);

		RestockItem(item);

		Destroy(selectedItem.gameObject);

		Player.Instance.AddMoney(item.Value);

		GameUI.Instance.UpdateMoneyText(Player.Instance.GetMoneyOwned());
		GameUI.Instance.RemoveItemFromInventory(item);

		RefreshItems();
	}

	private void RestockItem(Item item)
	{
		foreach(ShopItem shopItem in items)
		{
			if (item == shopItem.item)
			{
				shopItem.Restock();
			}
		}
	}

	private void CloseShop()
	{
		HideGraphics();
		gameObject.SetActive(false);

		OnShopClose();
	}

	private void SwitchToBuyMode()
	{
		LightModeButton(buyModeButton);
		FadeModeButton(sellModeButton);

		buyPanel.gameObject.SetActive(true);
		sellPanel.gameObject.SetActive(false);

		buyButton.gameObject.SetActive(true);
		sellButton.gameObject.SetActive(false);
	}

	private void SwitchToSellMode()
	{
		LightModeButton(sellModeButton);
		FadeModeButton(buyModeButton);

		buyPanel.gameObject.SetActive(false);
		sellPanel.gameObject.SetActive(true);

		buyButton.gameObject.SetActive(false);
		sellButton.gameObject.SetActive(true);
	}

	private void LightModeButton(Button button)
	{
		Color originalColor = button.targetGraphic.color;
		Color newColor = new(originalColor.r, originalColor.g, originalColor.b, 1f);

		button.targetGraphic.color = newColor;
	}

	private void FadeModeButton(Button button)
	{
		Color originalColor = button.targetGraphic.color;
		Color newColor = new(originalColor.r,originalColor.g, originalColor.b, 0.75f);

		button.targetGraphic.color = newColor;
	}
}

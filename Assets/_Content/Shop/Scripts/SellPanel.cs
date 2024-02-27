
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellPanel : MonoBehaviour
{
	[SerializeField] Shop parentShop;
    [SerializeField] GameObject shopItemPrefab;
	[SerializeField] RectTransform itemsParent;

    List<ShopItem> shopItems = new List<ShopItem>();

	private void OnEnable()
	{
		ClearList();
		PopulateList();
	}

	private void ClearList()
	{
		foreach (ShopItem item in shopItems)
		{
			Destroy(item.gameObject);
		}
		shopItems.Clear();
	}

	private void PopulateList()
	{
		foreach (Item item in Player.Instance.ownedItems)
		{
			ShopItem shopItem = Instantiate(shopItemPrefab, itemsParent.transform).GetComponent<ShopItem>();

			shopItem.item = item;
			shopItem.RefreshItem();

			shopItems.Add(shopItem);

			Toggle toggle = shopItem.GetComponent<Toggle>();
			toggle.onValueChanged.AddListener(_ => parentShop._ToggleSelectedItem(shopItem));
		}
	}
}
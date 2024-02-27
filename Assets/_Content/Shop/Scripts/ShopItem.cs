using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Toggle))]
public class ShopItem : MonoBehaviour
{
	[SerializeField] ItemType type;
	[SerializeField] string itemName;
	[SerializeField] int price;
	[SerializeField] Sprite itemSprite;
	
	[Space]
	[SerializeField] Image itemImage;
	[SerializeField] TextMeshProUGUI nameText;
	[SerializeField] TextMeshProUGUI priceText;
	[Space]
	[SerializeField] RectTransform fadeLayer;

	private Toggle toggle;

	public bool IsSold { get; private set; }

	private void Start()
	{
		toggle = GetComponent<Toggle>();

		nameText.text = itemName;
		priceText.text = price.ToString();
		itemImage.sprite = itemSprite;
	}

	public ItemType GetItemType()
	{
		return type;
	}

	public Item SellItem()
	{
		IsSold = true;
		return new Item(type, itemImage.sprite, itemName, price);
	}

	public void Disable()
	{
		toggle.interactable = false;
		fadeLayer.gameObject.SetActive(true);
	}

}

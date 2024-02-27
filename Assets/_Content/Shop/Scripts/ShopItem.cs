using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Toggle))]
public class ShopItem : MonoBehaviour
{
	[SerializeField] Item item;
	
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

		nameText.text = item.ItemName;
		priceText.text = item.Value.ToString();
		itemImage.sprite = item.Sprite;
	}

	public ItemType GetItemType()
	{
		return item.Type;
	}

	public Item SellItem()
	{
		IsSold = true;
		return item;
	}

	public void Disable()
	{
		toggle.interactable = false;
		fadeLayer.gameObject.SetActive(true);
	}

}

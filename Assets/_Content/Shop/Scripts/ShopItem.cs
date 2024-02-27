using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Toggle))]
public class ShopItem : MonoBehaviour
{
	[SerializeField] public Item item;
	
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

		RefreshItem();
	}

	public ItemType GetItemType()
	{
		return item.Type;
	}

	public Item MakeSale()
	{
		IsSold = true;
		return item;
	}

	public void Disable()
	{
		toggle.interactable = false;
		fadeLayer.gameObject.SetActive(true);
	}

	public void RefreshItem()
	{
		if (item == null) { return; }

		nameText.text = item.ItemName;
		priceText.text = item.Value.ToString();
		itemImage.sprite = item.Sprite;
	}

	public void Restock()
	{
		IsSold = false;

		gameObject.SetActive(true);
		toggle.interactable = true;
		fadeLayer.gameObject.SetActive(false);
	}

}

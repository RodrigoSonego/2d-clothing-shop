using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] Image itemImage;

	public Item Item { get; private set; }
	public bool IsEquipped { get; private set; }

	public void InsertItem(Item item)
	{
		this.Item = item;

		itemImage.sprite = item.Sprite;

		itemImage.enabled = true;
	}

	public Item GetItem()
	{
		return Item;
	}

	public void Clear()
	{
		itemImage.sprite = null;
		Item = null;

		itemImage.enabled = false;
		IsEquipped = false;
	}

	public void FadeImage()
	{
		itemImage.color = itemImage.color * 0.5f;
	}

	public void BrightenImage()
	{
		itemImage.color = Vector4.one;
	}

	public void SetIsEquipped(bool isEquipped)
	{
		IsEquipped = isEquipped;
	}
}

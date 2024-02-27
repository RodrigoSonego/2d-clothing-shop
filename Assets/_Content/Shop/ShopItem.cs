using UnityEngine;

public class ShopItem : MonoBehaviour
{
	[SerializeField] ItemType type;

	public ItemType GetItemType()
	{
		return type;
	}
}

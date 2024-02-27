using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemType type { get; private set; }
	public Sprite sprite { get; private set; }
	public string itemName { get; private set; }
	public int value { get; private set; }

	public Item() { }
	public Item (ItemType type, Sprite sprite, string itemName, int value)
	{
		this.type = type;
		this.sprite = sprite;
		this.itemName = itemName;
		this.value = value;
	}
}

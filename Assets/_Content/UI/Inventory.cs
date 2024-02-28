using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
	[SerializeField] List<InventorySlot> slots;

	private void Start()
	{
		foreach (InventorySlot slot in slots)
		{
			slot.GetComponent<Button>().onClick.AddListener(() => ToggleSlot(slot));
		}

		Clear();
	}

	private void ToggleSlot(InventorySlot slot)
	{
		if (slot.Item == null) return;

		if(slot.IsEquipped)
		{
			Player.Instance.UnequipItem(slot.GetItem());
			slot.BrightenImage();

			slot.SetIsEquipped(false);
			return;
		}

		Player.Instance.EquipItem(slot.GetItem());
		slot.FadeImage();

		slot.SetIsEquipped(true);
	}

	private void Clear()
	{
		foreach (var slot in slots)
		{
			slot.Clear();
		}
	}

	public void PopulateInventory(List<Item> items)
	{
		int slotIndex = 0;
		foreach (var item in items)
		{
			slots[slotIndex].InsertItem(item);

			++slotIndex;
		}
	}

	public void AddItem(Item item)
	{
		foreach(var slot in slots)
		{
			if (slot.Item != null) continue;

			slot.InsertItem(item);
			return;
		}
	}

	internal void RemoveItem(Item item)
	{
		foreach (var slot in slots)
		{
			if (slot.Item == item)
			{
				slot.Clear();
			}
		}
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
}

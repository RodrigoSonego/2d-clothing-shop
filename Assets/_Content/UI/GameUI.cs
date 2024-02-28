using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	[SerializeField] TextMeshProUGUI moneyText;
	[SerializeField] Inventory inventory;

	private void Awake()
	{
		if(Instance != null) { Destroy(Instance); }

		Instance = this;
	}

	public void UpdateMoneyText(int amount)
	{
		moneyText.text = amount.ToString();
	}

	public void AddItemToInventory(Item item)
	{
		inventory.AddItem(item);
	}

	public void RemoveItemFromInventory(Item item)
	{
		inventory.RemoveItem(item);
	}

	public void ShowInventory()
	{
		inventory.Show();
	}

	public void HideInventory()
	{
		inventory.Hide();
	}
}

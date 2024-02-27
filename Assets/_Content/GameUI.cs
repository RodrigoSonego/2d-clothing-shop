using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public static GameUI Instance;

	[SerializeField] TextMeshProUGUI moneyText;

	private void Awake()
	{
		if(Instance != null) { Destroy(Instance); }

		Instance = this;
	}

	public void UpdateMoneyText(int amount)
	{
		moneyText.text = amount.ToString();
	}
}

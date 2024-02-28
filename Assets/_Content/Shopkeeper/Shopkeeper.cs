using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
	[SerializeField] private Shop shop;
	[SerializeField] GameObject speechBubble;

	private void Start()
	{
		shop.OnShopClose += FinishInteraction;

		speechBubble.SetActive(false);
	}

	private void OpenShop()
	{
		shop.ShowShop();
	}

	private void FinishInteraction()
	{
		Player.Instance.SetCanMove(true);
		GameUI.Instance.UpdateMoneyText(Player.Instance.GetMoneyOwned());
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player.Instance.SetCanInteract(true);

		Player.Instance.Interact += OpenShop;

		speechBubble.SetActive(true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Player.Instance.SetCanInteract(false);
		Player.Instance.Interact -= OpenShop;

		speechBubble.SetActive(false);
	}
}

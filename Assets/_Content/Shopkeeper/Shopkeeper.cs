using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
	[SerializeField] private Shop shop;

	private void Start()
	{
		shop.OnShopClose += FinishInteraction;
	}

	private void OpenShop()
	{
		shop.ShowShop();
	}

	private void FinishInteraction()
	{
		Player.Instance.SetCanMove(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player.Instance.SetCanInteract(true);

		Player.Instance.Interact += OpenShop;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Player.Instance.SetCanInteract(false) ;
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed;
	[SerializeField] int money;
	[Space]
	[SerializeField] PlayerAnimations playerAnimation;

	private PlayerInputActions input;
	private Rigidbody2D rb;
	private bool canMove = true;
	private bool canInteract;

	public static Player Instance;
	public event Action Interact;

	public List<Item> ownedItems { get; private set; } = new List<Item>();
	public List<Item> equippedItems { get; private set; } = new List<Item>();

	void Start()
	{
		if (!Instance) { Instance = this; }

		rb = GetComponent<Rigidbody2D>();
		input = new PlayerInputActions();

		input.Player.Enable();
		input.Player.Interact.started += OnInteractPressed;

		GameUI.Instance.UpdateMoneyText(money);
	}

	private void OnInteractPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (canInteract == false) { return; }

		canMove = false;

		if (Interact != null) { Interact(); }
	}

	void FixedUpdate()
	{
		Move();
		playerAnimation.RenderItems(equippedItems);
	}

	private void Move()
	{
		if (canMove == false) { return; }

		Vector2 moveDirection = input.Player.Move.ReadValue<Vector2>();
		rb.velocity = moveDirection * moveSpeed;

		playerAnimation.UpdateAnimation(moveDirection);
	}

	public void SetCanInteract(bool canInteract)
	{
		this.canInteract = canInteract;
	}

	public void AddOwnedItem(Item item)
	{
		ownedItems.Add(item);

	}

	public void RemoveOwnedItem(Item item)
	{
		ownedItems.Remove(item);
	}

	public void SetCanMove(bool canMove)
	{
		this.canMove = canMove;
	}

	public int GetMoneyOwned()
	{
		return money;
	}

	public void DeductMoney(int amount)
	{
		money -= amount;
	}

	public void AddMoney(int amount)
	{
		money += amount;
	}

	public void EquipItem(Item item)
	{
		equippedItems.Add(item);
	}

	public void UnequipItem(Item item)
	{
		equippedItems.Remove(item);

		playerAnimation.ClearItemSprite(item.Type);
	}
}
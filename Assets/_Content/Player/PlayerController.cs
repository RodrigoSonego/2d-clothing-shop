using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] float moveSpeed;

	private PlayerInputActions input;
	private Rigidbody2D rb;
	private bool canMove = true;
	private bool canInteract;

	public static PlayerController Instance;
	public event Action Interact;

	List<Item> ownedItems = new List<Item>();

	void Start()
	{
		if (Instance == null) { Instance = this; }

		rb = GetComponent<Rigidbody2D>();
		input = new PlayerInputActions();

		input.Player.Enable();
		input.Player.Interact.started += OnInteractPressed;
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
	}

	private void Move()
	{
		if (canMove == false) { return; }

		Vector2 moveDirection = input.Player.Move.ReadValue<Vector2>();
		rb.velocity = moveDirection * moveSpeed;
	}

	public void SetCanInteract(bool canInteract)
	{
		this.canInteract = canInteract;
	}

	public void AddOwnedItem(Item item)
	{
		ownedItems.Add(item);
	}

	public void SetCanMove(bool canMove)
	{
		this.canMove = canMove;
	}
}
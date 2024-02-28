using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimations : MonoBehaviour
{
	private Animator animator;
	private SpriteRenderer spriteRenderer;

	[SerializeField] SpriteRenderer headRenderer;
	[SerializeField] SpriteRenderer upperBodyRenderer;
	[SerializeField] SpriteRenderer legsRenderer;
	[SerializeField] SpriteRenderer shoesRenderer;

	private void Start()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void UpdateAnimation(Vector2 input)
	{
		animator.SetBool("is_moving", input != Vector2.zero);

		if (input == Vector2.zero) { return; }

		animator.SetFloat("moveX", input.x);
		animator.SetFloat("moveY", input.y);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			renderer.flipX = input.x < 0;
		}
	}

	public void RenderItems(List<Item> equippedItems)
	{
		Rect mainRect = spriteRenderer.sprite.textureRect;

		foreach (var item in equippedItems)
		{
			Texture2D itemTex = item.Texture;
			Sprite sprite = Sprite.Create(itemTex, mainRect, new(0.5f, 0.5f), 32, 1);
			switch (item.Type)
			{
				case ItemType.UpperBody:
					upperBodyRenderer.sprite = sprite;
					break;
				case ItemType.Leggings:
					legsRenderer.sprite = sprite;
					break;
				case ItemType.Shoes:
					shoesRenderer.sprite = sprite;
					break;
				case ItemType.Hat:
					headRenderer.sprite = sprite;
					break;
				default:
					break;
			}
		}
	}

	public void ClearItemSprite(ItemType type)
	{
		switch (type)
		{
			case ItemType.UpperBody:
				upperBodyRenderer.sprite = null;
				break;
			case ItemType.Leggings:
				legsRenderer.sprite = null;
				break;
			case ItemType.Shoes:
				shoesRenderer.sprite = null;
				break;
			case ItemType.Hat:
				headRenderer.sprite = null;
				break;
			default:
				break;
		}

	}
}

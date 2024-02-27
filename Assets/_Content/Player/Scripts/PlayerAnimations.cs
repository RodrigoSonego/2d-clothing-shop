using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void UpdateAnimation(Vector2 input)
	{
		animator.SetBool("is_moving", input != Vector2.zero);

		if(input == Vector2.zero) { return; }

		animator.SetFloat("moveX", input.x);
		animator.SetFloat("moveY", input.y);

		foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
		{
			renderer.flipX = input.x < 0;
		}
	}
}

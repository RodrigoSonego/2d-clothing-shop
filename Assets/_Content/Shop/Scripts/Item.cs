using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
	[SerializeField] ItemType type;
	[SerializeField] Sprite spriteIcon;
	[SerializeField] string itemName;
	[SerializeField] int value;
	[SerializeField] Texture2D texture;

	public ItemType Type { get { return type; } }
	public Sprite Sprite { get { return spriteIcon; } }
	public string ItemName { get { return itemName; } }
	public int Value { get { return value; } }
	public Texture2D Texture { get { return texture; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using localSystem;

[CreateAssetMenu(menuName = "Scriptable/SpriteSettings", fileName = "sprite_list_setting")]
public class SpriteSettings : ScriptableObject
{
	public localSystem.SerializeDicSprite SpriteDict = null;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using localSystem;
using CP.useful;

[CreateAssetMenu(menuName = "Scriptable/SpriteSettings", fileName = "sprite_list_setting")]
public class SpriteSettings : ScriptableObject
{
	public SerializeDicSprite SpriteDict = null;
}

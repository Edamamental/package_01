using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CP.useful;

public class SoundManger : SingletonMonoBehaviour<SoundManger>
{
	public AudioSource PlaySound(AudioSource prefab, float delay)
	{
		return PlaySoundAtPos(prefab, Vector3.zero, delay);
	}



	public AudioSource PlaySoundAtPos(AudioSource prefab, Vector3 pos, float delay = 0)
	{
		if(prefab != null)
		{
			AudioSource aAudio = Instantiate(prefab, pos, Quaternion.identity);
			Play(aAudio, delay);
			return aAudio;
		}
		return null;
	}

	public AudioSource PlaySoundAtTrans(AudioSource prefab, Transform trans, float delay = 0)
	{
		if(prefab != null)
		{
			AudioSource aAudio = Instantiate(prefab, trans, false);
			Play(aAudio, delay);
			return aAudio;
		}
		return null;
	}

	

	public void Play(AudioSource source, float delay = 0)
	{
		source.PlayDelayed(delay);
		Destroy(source.gameObject, source.clip.length + delay);
	}

	public void PlayLoopSound(AudioSource target)
	{
		if(target != null)
		{
			target.Play();
		}
		
	}

	public AudioSource SetAudio(AudioSource prefab, Transform trans)
	{
		if(prefab != null)
		{
			return Instantiate(prefab, trans, false);
		}
		return null;
		
	}
}

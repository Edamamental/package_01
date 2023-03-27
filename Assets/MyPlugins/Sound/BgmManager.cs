using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using CP.useful;

public class BgmManager : SingletonMonoBehaviour<BgmManager>
{
	[SerializeField] AudioMixer mixer = null;
	[SerializeField] SoundData[] BGMSoundDataArray = null;

	protected override void Awake()
	{
		base.Awake();
		foreach(SoundData data in BGMSoundDataArray)
		{
			mixer.GetFloat(data.MixerGroupName, out data.BaseVolume);
		}
	}

	public void PlayBGM(int trackNum = -1)
	{
		foreach (SoundData data in BGMSoundDataArray)
		{
			if(trackNum == -1)
			{
				data.AudioSource.time = 0;
				StartCoroutine(BGMVolume(-80, data.BaseVolume, data.MixerGroupName,0));
				data.AudioSource.Play();
			}
			else
			{
				if(trackNum == data.TrackNum)
				{
                    data.AudioSource.time = 0;
                    StartCoroutine(BGMVolume(-80, data.BaseVolume, data.MixerGroupName, 0));
					data.AudioSource.Play();
				}
                else
                {
                    data.AudioSource.time = 0;
                    StartCoroutine(BGMVolume(0, -80, data.MixerGroupName, 0));
                    data.AudioSource.Play();
                }
			}
		}
	}

    public void AddBGM(int trackNum)
    {
        foreach (SoundData data in BGMSoundDataArray)
        {
            if (trackNum == data.TrackNum)
            {
                StartCoroutine(BGMVolume(-80, data.BaseVolume, data.MixerGroupName, 0));
                data.AudioSource.Play();
            }
        }
    }

    public void RemoveBGM(int trackNum, float fadeTime = 1)
    {
        foreach (SoundData data in BGMSoundDataArray)
        {
            if (trackNum == data.TrackNum)
            {
                StartCoroutine(BGMVolume(data.BaseVolume, -80, data.MixerGroupName, fadeTime));
                data.AudioSource.Play();
            }
        }

    }

	public void StopBGM(float time = 0.1f,int trackNum = -1)
	{
		//BGMAudio.Stop();
		foreach (SoundData data in BGMSoundDataArray)
		{
			if (trackNum == -1)
			{
				StartCoroutine(BGMVolume(data.BaseVolume, -80, data.MixerGroupName, time));
			}
			else
			{
				if (trackNum == data.TrackNum)
				{
					StartCoroutine(BGMVolume(data.BaseVolume, -80,data.MixerGroupName,time));
				}
			}
		}
	}

	IEnumerator BGMVolume(float start, float end, string trackName, float time = 1)
	{
		float timer = 0;
		float volume = 0;
		mixer.GetFloat(trackName, out volume);
		mixer.SetFloat(trackName, start);
		while (timer <= time)
		{
			mixer.SetFloat(trackName, Mathf.Lerp(start, end, timer/time));
			timer += Time.deltaTime;
			yield return null;
		}
		mixer.SetFloat(trackName, end);
		yield break;
	}

	public void PauseBGM(bool value)
	{
		if (value)
		{
            foreach (SoundData data in BGMSoundDataArray)
            {
                data.AudioSource.Pause();
            }
		}
		else
		{
            foreach (SoundData data in BGMSoundDataArray)
            {
                data.AudioSource.Play();
            }
		}
		
	}
}

[System.Serializable]
public class SoundData
{
	public AudioSource AudioSource = null;
	public float BaseVolume = 0;
	public string MixerGroupName = "None";
	public int TrackNum = 0;

}

using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Audio[] sounds;

	void Awake() {
		foreach (Audio a in sounds) {
			a.source = gameObject.AddComponent<AudioSource>();
			a.source.clip = a.clip;
			a.source.volume = a.volume;  
			a.source.pitch = a.pitch;
		}
	}

	public void PlayAudio(string name) {
		Audio s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}
}

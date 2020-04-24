using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
	public class AudioManager : MonoBehaviour
	{
		
		public static AudioManager Instance { get; private set; }

		[SerializeField] private AudioMixerGroup mixerGroup;
		
		[SerializeField] private Sound[] sounds;

		private void Awake()
		{
			if (Instance != null)
			{
				Destroy(gameObject);
			}
			else
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}

			foreach (var s in sounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				s.source.loop = s.loop;

				s.source.outputAudioMixerGroup = mixerGroup;
			}
		}

		public void Play(string sound)
		{
			var s = Array.Find(sounds, item => item.name == sound);
			if (s == null)
			{
				return;
			}

			s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
			s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

			s.source.Play();
		}

	}
}

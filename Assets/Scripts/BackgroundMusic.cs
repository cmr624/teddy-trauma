using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

	public AudioClip Music;
	public AudioSource MusicSource;

	// Use this for initialization
	void Start()
	{
		MusicSource.clip = Music;
		MusicSource.Play();
	}
}

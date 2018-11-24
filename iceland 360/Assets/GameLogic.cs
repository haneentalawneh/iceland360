using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameLogic : MonoBehaviour
{
	public GameObject[] screens;
	public GameObject movieScreen;
	public GameObject rain;
	VideoPlayer videoPlayer;
	public GameObject play;
	public GameObject pause;
	public GameObject playAgain;
	public GameObject ControlScreen;
	public GvrAudioSource src;
	int index = 0;
	bool isFinished = false;
	int currentTime = 0;

	void Start ()
	{
		videoPlayer = movieScreen.GetComponent<VideoPlayer> ();
	}

	void Update ()
	{
		if (!videoPlayer.isPlaying && !isFinished) {
			if (videoPlayer != null) {
				if (videoPlayer.time >= 29.5) {
					//Video has finshed playing!
					play.SetActive (false);
					pause.SetActive (false);
					toggleObject (playAgain);

					src.Stop ();
					isFinished = true;
				}
			}
		}
	}

	public void onStartClicked ()
	{
		toggleObject (screens [0]);
		toggleObject (screens [1]);
	
	}

	public void onActionClicked ()
	{
		toggleObject (screens [1]);
		toggleObject (screens [2]);

	}

	public void StartMovie (int index)
	{
		this.index = index;
		toggleMenu ();
		videoPlayer.url = (index != 0) ? @"https://dl.dropbox.com/s/3i7kcyf8hkcffxa/WaterFalls.m4v": @"https://dl.dropbox.com/s/2vzt0lycm02lwes/Geysir.m4v";
		PlayMovie ();

	}

	public void OnPauseClicked ()
	{
		if (videoPlayer != null) {
			
			if (videoPlayer.isPlaying) {
				videoPlayer.Pause ();
				src.Pause ();
			
			} else {
				videoPlayer.Play ();
				src.Play ();
			}

			toggleObject (play);
			toggleObject (pause);
		}
	}

	void toggleObject (GameObject obj)
	{
		obj.SetActive (!obj.activeSelf);
		
	}

	public void PlayMovie ()
	{	
		isFinished = false;
		playAgain.SetActive (false);

		videoPlayer.Prepare ();
		videoPlayer.Play ();
		pause.SetActive (true);
		src.Play ();
	
	}

	public void toggleMenu ()
	{
		toggleObject (ControlScreen);
		toggleObject (screens [0]);
		toggleObject (rain);
		toggleObject (movieScreen);

		if (!movieScreen.activeSelf) {
			src.Stop ();
		}
	}
}

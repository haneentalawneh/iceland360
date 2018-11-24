using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameLogic : MonoBehaviour
{
	public GameObject[] screens;
	public VideoClip[] movies;
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
		Debug.Log("frame:" + videoPlayer.time);
		Debug.Log ((double)videoPlayer.url.Length);

		if (!videoPlayer.isPlaying && !isFinished) {
			if (videoPlayer != null) {
				if (videoPlayer.frame != null) {
					
					if ((double)videoPlayer.url.Length == videoPlayer.time) {
						//Video has finshed playing!
					
						toggleObject (playAgain);
						isFinished = true;
					}
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
		PlayMovie ();

	}

	//public void

	public void OnPauseClicked ()
	{
		src.Stop ();
		if (videoPlayer != null) {
			
			if (videoPlayer.isPlaying) {
				videoPlayer.Pause ();
			
			} else {
				videoPlayer.Play ();
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

		//videoPlayer.clip = movies [this.index];
		videoPlayer.Prepare ();
		videoPlayer.Play ();
	
	}

	public void toggleMenu ()
	{
		toggleObject (ControlScreen);
		toggleObject (screens [0]);
		toggleObject (rain);
		toggleObject (movieScreen);

		if (movieScreen.activeSelf == true) {
			src.Play ();
		} else {
			src.Stop ();
		}
	}

}

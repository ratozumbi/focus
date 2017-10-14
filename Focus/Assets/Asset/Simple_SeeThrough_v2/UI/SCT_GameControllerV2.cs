using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCT_GameControllerV2 : MonoBehaviour 
{
	public Transform MPlayer;
	public Transform RPlayer;
	public GameObject Cam_list;
	public GameObject Cam_play;
	public GameObject UI_arrow;

	private bool _isplay = false;
	private float _speed = 0.02f;
	private Vector3 _nPos;
	private Vector3 _nRot;
	private Vector2 _dir = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		SwitchCam ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(_dir.x != 0 || _dir.y != 0)
		{
			//Move Character
			_nPos = MPlayer.localPosition;
			_nPos.x += _speed * _dir.x;
			_nPos.z += _speed * _dir.y;
			MPlayer.localPosition = _nPos;
		}
	}

	public void MovePlayer(int dir)
	{
		//Set Direction
		if(dir==0) {_dir.x=0;_dir.y=0;_nRot.y=0f;} //RESET
		if(dir==1) {_dir.x=0;_dir.y=1;_nRot.y=270f;} //RIGHT
		if(dir==2) {_dir.x=0;_dir.y=-1;_nRot.y=90f;} //LEFT
		if(dir==3) {_dir.x=-1;_dir.y=0;_nRot.y=180f;} //UP
		if(dir==4) {_dir.x=1;_dir.y=0;_nRot.y=0f;} //BOT

		//Rotate Character
		if(dir>0) RPlayer.localRotation = Quaternion.Euler(_nRot);
	}
	public void SwitchCam()
	{
		if (_isplay)
		{
			Cam_play.SetActive (true);
			Cam_list.SetActive (false);
			UI_arrow.SetActive (true);
			_isplay = false;
		}
		else 
		{
			Cam_play.SetActive (false);
			Cam_list.SetActive (true);
			UI_arrow.SetActive (false);
			_isplay = true;
		}
	}
}

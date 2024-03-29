﻿using UnityEngine;
using System.Collections;

namespace SaadKhawaja{
public class TurnToWall : MonoBehaviour {

	public GameManager Game;
	bool isWall;

	void OnMouseDown()
	{
		string [] splitter = this.gameObject.name.Split (',');
		if(!isWall)
		{
			Game.addWall(int.Parse(splitter[0]),int.Parse(splitter[1]));
			isWall = true;
			this.GetComponent<Renderer>().material.color = Color.red;
		}
		else
		{
			Game.removeWall(int.Parse(splitter[0]),int.Parse(splitter[1]));
			isWall = false;
			this.GetComponent<Renderer>().material.color = Color.white;
		}
	}
}}
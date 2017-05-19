using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class JoyTypeRegions : MonoBehaviour {

	public bool isLeft;
	public bool inputGiven;

	public Text[] regions = new Text[10];
	public int active_region = 0;

	public float x;
	public float y;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(isLeft) {
			x = (float)Math.Round(Input.GetAxis("LSX"), 2);
			y = (float)Math.Round(Input.GetAxis("LSY"), 2);
		}
		else {
			x = (float)Math.Round(Input.GetAxis("RSX"), 2);
			y = (float)Math.Round(Input.GetAxis("RSY"), 2);
		}

		if(y == 1) {    // up
			active_region = 2;
		}
		else if(y == -1) {  // down
			active_region = 8;
		}
		else if(x == 1) {   // right
			active_region = 6;
		}
		else if(x == -1) {  // left
			active_region = 4;
		}
		else if(y > 0.3) {  // diag up
			if(x > 0.3) //right
				active_region = 3;
			else if(x < -0.3)   // left
				active_region = 1;
			else
				active_region = 0;
		}
		else if(y < -0.3) {  // diag down
			if(x > 0.3) //right
				active_region = 9;
			else if(x < -0.3)   // left
				active_region = 7;
			else
				active_region = 0;
		}
		else {
			active_region = 0;
		}
		if(active_region == 0)
			inputGiven = false;

		int i = 0;
		while(i < regions.Length) {
			if(regions[i] != null) {
				if(i == active_region)
					regions[i].color = Color.green;
				else
					regions[i].color = Color.white;
			}
			i++;
		}
	}
}

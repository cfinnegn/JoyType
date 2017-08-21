using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public abstract class JoyTypeController : MonoBehaviour {
	public JoyTypeRegions left_regions;
	public JoyTypeRegions right_regions;
	public string[] letters;

	public bool backspaced = false;
	public static float max_bcksp = 0.75f;  // starting backspace delay window
	public static float min_bcksp = 0.1f;   // fastest backspace delay window
	public float bcksp_timer = max_bcksp;
	public int bcksp_scale = 1;             // coefficient for backspace accel

	public Text input;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		if(left_regions.regions[left_regions.active_region] != null)
			left_region_active();
		else
			left_region_inactive();
		if(right_regions.regions[right_regions.active_region] != null)
			right_region_active();
		else
			right_region_inactive();
		// unflag backspace
		if(!Input.GetButton("RSZ")) {
			backspaced = false;
			bcksp_timer = max_bcksp;
			bcksp_scale = 1;
		}
		// backspace
		if(Input.GetButton("RSZ")) {
			bcksp_timer -= Time.deltaTime;
			if(!backspaced || bcksp_timer <= 0) {
				backspaced = true;
				// trim end of string if string non empty
				if(input.text.Length >= 1)
					input.text = input.text.Substring(0, input.text.Length - 1);
				// holding down backspace will allow for multiple deletions at increasing rate
				if(bcksp_timer <= 0) {
					bcksp_timer = (float)System.Math.Pow(0.8f, bcksp_scale) * max_bcksp;
					bcksp_timer = (bcksp_timer > min_bcksp) ? bcksp_timer : min_bcksp;
					bcksp_scale++;
				}
			}
		}
	}

	public abstract void left_region_active();
	public abstract void right_region_active();
	public abstract void left_region_inactive();
	public abstract void right_region_inactive();
}
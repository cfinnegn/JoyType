using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class JoyTypeAlphaDuMono : MonoBehaviour {

	public JoyTypeRegions left_regions;
	public JoyTypeRegions right_regions;
	public string[] letters;

	public bool backspaced = false;

	public Text input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// setup right regions based on left region
		if(left_regions.regions[left_regions.active_region] != null) {
			string ltext = left_regions.regions[left_regions.active_region].text;
			Regex non_space = new Regex("[^ \n]");
			MatchCollection matches = non_space.Matches(ltext);
			right_regions.regions[2].text = matches[0].Value;
			right_regions.regions[4].text = matches[1].Value;
			right_regions.regions[6].text = matches[2].Value;
			right_regions.regions[8].text = matches[3].Value;
			// TODO: Add predictive text
		}
		else {
			int i = 0;
			while (i < right_regions.regions.Length) {
				if(right_regions.regions[i] != null)
					right_regions.regions[i].text = "";
				i++;
			}
		}

		// add letters when right region triggered
		if(right_regions.regions[right_regions.active_region] != null &&
			right_regions.regions[right_regions.active_region].text != "") {
			if(!right_regions.inputGiven) {
				string letter = right_regions.regions[right_regions.active_region].text;
				input.text += (letter == "-") ? " " : letter;	// change dash to space 
				right_regions.inputGiven = true;
			}
		}
		if(!Input.GetButton("RSZ"))
			backspaced = false;

		if(Input.GetButton("RSZ") && !backspaced) {
			backspaced = true;
			if(input.text.Length > 1)
				input.text = input.text.Substring(0, input.text.Length - 1);
		}
	}
}

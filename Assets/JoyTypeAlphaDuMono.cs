using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class JoyTypeAlphaDuMono : JoyTypeController {

	public override void left_region_active() {
		string ltext = left_regions.regions[left_regions.active_region].text;
		Regex non_space = new Regex("[^ \n]");
		MatchCollection matches = non_space.Matches(ltext);
		right_regions.regions[2].text = matches[0].Value;
		right_regions.regions[4].text = matches[1].Value;
		right_regions.regions[6].text = matches[2].Value;
		right_regions.regions[8].text = matches[3].Value;
		// TODO: Add predictive text	
	}

	public override void left_region_inactive() {
		int i = 0;
		// clear out right region text
		while(i < right_regions.regions.Length) {
			if(right_regions.regions[i] != null)
				right_regions.regions[i].text = "";
			i++;
		}
	}

	public override void right_region_active() {
		if(right_regions.regions[right_regions.active_region].text != "") {	// TODO: predictive text
			if(!right_regions.inputGiven) {
				string letter = right_regions.regions[right_regions.active_region].text;
				input.text += (letter == "-") ? " " : letter;   // change dash to space 
				right_regions.inputGiven = true;
			}
		}
	}

	public override void right_region_inactive() { /*NoOp*/	}
	

}

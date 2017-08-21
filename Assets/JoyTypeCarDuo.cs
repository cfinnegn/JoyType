using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class JoyTypeCarDuo : JoyTypeController {
	public override void left_region_active() {
		if(left_regions.regions[left_regions.active_region].text != "") {
			if(!left_regions.inputGiven) {
				string duo = left_regions.regions[left_regions.active_region].text;
				Regex first_non_space = new Regex("^[^ \n]");
				MatchCollection matches = first_non_space.Matches(duo);
				input.text += "" + matches[0].Value;  
				left_regions.inputGiven = true;
			}
		}
	}

	public override void left_region_inactive() {	}

	public override void right_region_active() {
		if (right_regions.regions[right_regions.active_region].text != "") {
			if(!right_regions.inputGiven) {
				string duo = right_regions.regions[right_regions.active_region].text;
				Regex first_non_space = new Regex("^[^ \n]");
				MatchCollection matches = first_non_space.Matches(duo);
				input.text += "" + matches[0].Value;
				right_regions.inputGiven = true;
			}
		}
	}

	public override void right_region_inactive() {	}


}

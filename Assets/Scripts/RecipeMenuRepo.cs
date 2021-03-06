﻿using System;
using System.Collections;
using System.Collections.Generic;
using MagicLeapTools;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
/*
 * WelcomeScreenRepo
 * TutorialLandingRepo
 * TutorialGesturesRepo
 * RecipeChooserRepo
 * RecipeInformationRepo
 * StepDisplay Repo
 *
 */
public class RecipeMenuRepo : MonoBehaviour
{
	public ControlInput controlInput;
  	public GameObject WorldCanvas;
  	public GameObject _camera;

	private void Awake()
	{
		switch (RepositionVars.RecipeMenuIndex)
		{
			// WelcomeScreen
			case 0:
				WorldCanvas.transform.position = RepositionVars.WelcomeScreen_position;
				WorldCanvas.transform.rotation = RepositionVars.WelcomeScreen_rotation;
				break;

			// StepDisplay
			case 1:
				WorldCanvas.transform.position = RepositionVars.StepDisplay_position;
				WorldCanvas.transform.rotation = RepositionVars.StepDisplay_rotation;
				break;
			
			// TutorialSuccess
			case 2:
				WorldCanvas.transform.position = RepositionVars.TutorialSuccess_position;
				WorldCanvas.transform.rotation = RepositionVars.TutorialSuccess_rotation;
				break;

			// RecipeInformation
			case 3:
				WorldCanvas.transform.position = RepositionVars.RecipeInformation_position;
				WorldCanvas.transform.rotation = RepositionVars.RecipeInformation_rotation;
				break;
		}

		RepositionVars.RecipeMenu_position = WorldCanvas.transform.position;
		RepositionVars.RecipeMenu_rotation = WorldCanvas.transform.rotation;

		RepositionVars.LoadIndex = 5;
	}

	// Update is called once per frame
	void Update()
	{
		if (controlInput.Bumper) {
			WorldCanvas.transform.position = _camera.transform.position + _camera.transform.forward * RepositionVars._distance;
			RepositionVars.RecipeMenu_position = WorldCanvas.transform.position;

			WorldCanvas.transform.rotation = _camera.transform.rotation;
			RepositionVars.RecipeMenu_rotation = WorldCanvas.transform.rotation;
		}
	}
}

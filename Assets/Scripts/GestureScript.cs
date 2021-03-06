﻿/**
 * Magic Leap tutorial from
 * https://creator.magicleap.com/learn/guides/gestures-in-unity
 */
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.MagicLeap;

public class GestureScript : MonoBehaviour {
	
	private MLHandKeyPose[] gestures;	// Holds the different gestures we will look for
	private AssetBundle myLoadedAssetBundle;
	private string[] stepPaths;
	private int stepIndex; // marks the recipe step

	void Start () 
	{
		MLHands.Start();

		gestures = new MLHandKeyPose[2];
		
		gestures[0] = MLHandKeyPose.Ok;
		gestures[1] = MLHandKeyPose.Thumb;
		
		MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);
	}

	void onDestroy() 
	{
		MLHands.Stop();
	}

	void Update() 
	{
		if (GetOkay())
		{
			// unload active scene, then load recipe information
      		string scene = SceneManager.GetActiveScene().name;
            
      		if (Equals(scene, Loader.Scene.RecipeInformation.ToString()))
            {
	            Loader.Load(Loader.Scene.StepDisplay);
        		Hold(1);
      		}
		}
	}

	bool GetGesture(MLHand hand, MLHandKeyPose type)	
	{
		if (hand != null) 
		{
			if (hand.KeyPose == type) 
			{
				if (hand.KeyPoseConfidence > 0.9f) 
				{
					return true;
				}
			}
		}
		
		return false;
	}
	
	// Cleans up logic for reading the 'All Good' gesture
	bool GetOkay() 
	{
		if (GetGesture(MLHands.Left, MLHandKeyPose.Thumb) || GetGesture(MLHands.Right, MLHandKeyPose.Thumb)) 
		{
			return true;
		}

		else 
		{
			return false;
		}
	}

  void Hold(int delay)
  {
  	Stopwatch stopWatch = new Stopwatch();

    stopWatch.Start();
    float curr = stopWatch.ElapsedMilliseconds / 1000;

    while ( curr < delay) 
    {
      curr = stopWatch.ElapsedMilliseconds / 1000;
    }
    stopWatch.Stop();
  }

}

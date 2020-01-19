﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class StepCanvas : MonoBehaviour
{
	public List<string> URLs = new List<string>();
    public GameObject canvas;
    public int yCoord;
    public int xCoord;
    // Start is called before the first frame update
    //Timer work below under contruction
    public int timeLeft; //Seconds Overall
    public Text countdown; //UI Text Object
    public int hours;
    public int minutes;
    public int seconds;
    public String niceTime;
    public int z;
    void Start()
    {
        yCoord=-20;
        xCoord= 210;
        int height=50;
        int width=50;
        URLs.Add("https://food.fnr.sndimg.com/content/dam/images/food/fullset/2012/2/24/0/ZB0202H_classic-american-grilled-cheese_s4x3.jpg.rend.hgtvcom.616.462.suffix/1371603614279.jpeg");
        URLs.Add("https://i0.wp.com/cdn-prod.medicalnewstoday.com/content/images/articles/299/299147/cheese-varieties.jpg?w=1155&h=1537");

        foreach (string currentURL in URLs)
        {
            
            canvas = GameObject.Find("Canvas");
            GameObject NewObj = new GameObject(); //Create the GameObject
            RawImage NewImage = NewObj.AddComponent<RawImage>(); //Add the Image Component script
            NewImage.transform.SetParent(canvas.transform, false);
            NewObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(xCoord, yCoord, 0);
            NewObj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            yCoord = yCoord - 50;
            NewObj.SetActive(true); //Activate the GameObject
            StartCoroutine(GetTexture(currentURL, NewObj));
        }
        
        Debug.Log("Out of URL Loop");
        countdown = GameObject.Find("Timer").GetComponent<Text>();
        timeLeft = 10;
        z = timeLeft / 2;
//        timeLeft = 10;
//        for(int i = 0; i < 5; i++)
//        {
//            StartCoroutine("LoseTime");
//            Time.timeScale = 1; //Just making sure that the timeScale is right
//        }
    }
    
    void Update()
    {
       
    }

    void CountDown(Text TimeObj, float Totaltime) {
        minutes += Time.deltaTime;
        float seconds = minutes % 60;
        //Reduce the total time by the amount of seconds elapsed...
        Totaltime -= seconds;
        
        //yield return ("it works"); new WaitForSeconds(1.0f);
        hours = Mathf.FloorToInt(timeLeft / 3600F);
        minutes = Mathf.FloorToInt((timeLeft - (hours*3600)) / 60F);
        seconds = Mathf.FloorToInt(timeLeft - (hours * 3600) - (minutes * 60));
        niceTime = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        
        countdown.text = ("" + niceTime); //Showing the Score on the Canvas

        
        TimeObj.text = "Time Elapsed: " + seconds.ToString("0")+" seconds"+ " Time Remaining: "+ (int)Totaltime;
        if (Totaltime <= 40f) {
            PanelObj.SetActive(true);
            TimeText.enabled = false;
        }
    }
    
    IEnumerator GetTexture(string thisURL, GameObject currrentImage) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(thisURL);
    	yield return www.SendWebRequest();

        if(www.isNetworkError) {
            Debug.Log(www.error);
        }
        else {
            currrentImage.GetComponent<RawImage>().texture = DownloadHandlerTexture.GetContent(www);
        }
        
    }


}

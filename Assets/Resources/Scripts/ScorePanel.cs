using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : Singleton<ScorePanel>
{

    private Text timeValue;
    private float timeElapsed;

    private Text distanceField;
    //public float distance;
    public bool isGameOver;

    private Player player;

    // Use this for initialization
    override protected void Awake () {
        player = GameObject.FindObjectOfType<Player>();
        timeValue = transform.Find("TimeValue").GetComponent<Text>();
        distanceField = transform.Find("DistanceValue").GetComponent<Text>();
        timeElapsed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(isGameOver)
        {
            return;
        }
        timeElapsed += Time.deltaTime;
        int timeElapsedInt = (int)timeElapsed;


        //convert timeElapsed to displayTime
        int hours = timeElapsedInt / 3600;
        int timeLeft = timeElapsedInt % 3600;
        int mins = timeLeft / 60;
        timeLeft = timeLeft % 60;
        int secs = timeLeft;

        string secsPadded = (secs < 10) ? "0" + secs : "" + secs;
        string minsPadded = (mins < 10) ? "0" + mins : "" + mins;
        string hoursPadded = (hours < 10) ? "0" + hours : "" + hours;
        string timeString = hoursPadded + ":" + minsPadded + ":" + secsPadded;
        timeValue.text = timeString;

        //make distance displayable
        int distanceInt = (int)player.distanceTravelled;
        distanceField.text = distanceInt.ToString();

	}
}

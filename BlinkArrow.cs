﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TrainingBlink : MonoBehaviour
{

    public Image UpArrow; //image to toggle
    public Image DownArrow; //image to toggle
    public Image LeftArrow; //image to toggle
    public Image RightArrow; //image to toggle  
    public int num_of_blink_arrow = 2;
    public float current_time = 0.0f;

    public float interval = 0.1f;
    public float startDelay = 0.1f;

    public int blinkcnt = 0;
    public int BlinkCount = 40;

    bool isBlinking = false;
    bool arrow0 = true, arrow1 = true, arrow2 = true, arrow3 = true;
    public int cnt0 = 0, cnt1 = 0, cnt2 = 0, cnt3 = 0;
    int count = 0;
    int buttonIndexNum = 0;
    int targetChange = 0;
    int rndnum = 0;
    public int order = 0;
    public int[] ranArr = { 0, 1, 2, 3 };

    bool blinkstate = true;
    UIVA_Client theClient = null;

    Image pubimg;

    void Start()
    {
        theClient = new UIVA_Client("localhost");
        UpArrow.enabled = true;
        DownArrow.enabled = true;
        LeftArrow.enabled = true;
        RightArrow.enabled = true;
    }
    private void Update()
    {
        current_time += Time.deltaTime;

        //Restart blinking
        if (current_time > 10.0f && blinkstate == true)
        {
            blinkstate = false;
            arrow0 = true;
            arrow1 = true;
            arrow2 = true;
            arrow3 = true;
            blinkcnt = 0;
            Blink();
        }
        else if (current_time > 20.0f)
        {
            current_time = 0.0f;
            blinkstate = true;
        }
    }
    public void Blink()
    {
        if (blinkcnt < BlinkCount)
        {
            rndnum = UnityEngine.Random.Range(0, 4);
            if (rndnum == 0 && arrow0 == true)
            {
                arrow0 = false;

                pubimg = UpArrow;
                if (isBlinking)
                    return;
                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 0 && arrow0 == false)
            {
                Blink();
            }
            else if (rndnum == 1 && arrow1 == true)
            {
                arrow1 = false;

                pubimg = DownArrow;
                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 1 && arrow1 == false)
            {
                Blink();
            }
            else if (rndnum == 2 && arrow2 == true)
            {
                arrow2 = false;

                pubimg = LeftArrow;
                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 2 && arrow2 == false)
            {
                Blink();
            }
            else if (rndnum == 3 && arrow3 == true)
            {
                arrow3 = false;

                pubimg = RightArrow;
                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }

            }
            else if (rndnum == 3 && arrow3 == false)
            {
                Blink();
            }

            if (arrow0 == false && arrow1 == false && arrow2 == false && arrow3 == false)
            {
                arrow0 = true;
                arrow1 = true;
                arrow2 = true;
                arrow3 = true;
            }
        }
        else
        {
            targetChange++;
            if (targetChange == 4)
            {
                theClient.Press(2); //training이 끝났다는 신호를 보내기 위한 Button
            }
            /*   theClient.GetOrder();
               switch (theClient.recStr)
               {
                   case "0":
                       order = 0;
                       break;
                   case "1":
                       order = 1;
                       break;
                   case "2":
                       order = 2;
                       break;
                   case "3":
                       order = 3;
                       break;
                   default:
                       break;
               }
            */
        }

    }
    public void ToggleState()
    {
        pubimg.enabled = !pubimg.enabled;
        count++;
        if (count == num_of_blink_arrow)
        {
            CancelInvoke();
            if (ranArr[targetChange] == rndnum)
                buttonIndexNum = 1;
            else
                buttonIndexNum = 0;
            theClient.Press(buttonIndexNum);

            if (rndnum == 0) cnt0++;
            else if (rndnum == 1) cnt1++;
            else if (rndnum == 2) cnt2++;
            else cnt3++;

            blinkcnt++;
            count = 0;
            isBlinking = false;
            Blink();
        }
    }
}
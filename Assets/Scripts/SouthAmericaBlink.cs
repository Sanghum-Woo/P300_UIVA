using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SouthAmericaBlink : MonoBehaviour
{
    ColorBlock cb;
    public Button NorthAmerica; //image to toggle
    public Button SouthAmerica; //image to toggle
    public Button Asia; //image to toggle
    public Button Africa; //image to toggle  
    public Button Oceania; //image to toggle 
    public Button Europe; //image to toggle 

    public int num_of_blink_arrow = 2;
    public float current_time = 0.0f;

    public float interval = 0.1f;
    public float startDelay = 0.1f;
    public float timebetweenarrows = 0.1f;

    public int blinkcnt = 0;
    public int BlinkCount = 60;

    bool isBlinking = false;
    bool Button0 = true, Button1 = true, Button2 = true, Button3 = true, Button4 = true, Button5 = true;
    public int noA = 0, soA = 0, Asi = 0, Afr = 0, Oce = 0, Eur = 0;
    int count = 0;
    int buttonIndexNum = 0;
    int targetChange = 0;
    int rndnum = 0;
    public int[] ranArr = { 0, 1, 2, 3, 4, 5 };
    public string order = "";
    public int value = 6;

    string ipUIVAServer = "localhost";
    public string buttons;

    bool blinkstate = true;
    //UIVA_Client theClient = null;

    Button pubimg;

    void Start()
    {
        //theClient = new UIVA_Client(ipUIVAServer);
        cb.normalColor = Color.white;
        cb.colorMultiplier = 1.5f;
        NorthAmerica.colors = cb;
        SouthAmerica.colors = cb;
        Asia.colors = cb;
        Africa.colors = cb;
        Europe.colors = cb;
        Oceania.colors = cb;
    }
    private void Update()
    {
        current_time += Time.deltaTime;
        //if (targetChange == 4 && current_time < 10.0f)
        //{
        //    if (current_time > 5.0f) theClient.Disconnect();
        //}
        //Restart blinking
        if (current_time > 5.0f && blinkstate == true)
        {
            blinkstate = false;
            Button0 = true;
            Button1 = true;
            Button2 = true;
            Button3 = true;
            Button4 = true;
            Button5 = true;
            blinkcnt = 0;
            BlinkButton();
        }
        //else if (current_time > 35.0f)
        //{
        //    current_time = 0.0f;
        //    blinkstate = true;
        //}
    }
    public void BlinkButton()
    {
        if (blinkcnt < BlinkCount)
        {
            rndnum = UnityEngine.Random.Range(0, 6);
            if (rndnum == 0 && Button0 == true)
            {
                Button0 = false;
                buttonIndexNum = 0;
                //theClient.Press_O(buttonIndexNum);
                pubimg = NorthAmerica;

                if (isBlinking)
                    return;
                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 0 && Button0 == false)
            {
                BlinkButton();
            }
            else if (rndnum == 1 && Button1 == true)
            {
                Button1 = false;
                buttonIndexNum = 1;
                //theClient.Press_O(buttonIndexNum);
                pubimg = SouthAmerica;

                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 1 && Button1 == false)
            {
                BlinkButton();
            }
            else if (rndnum == 2 && Button2 == true)
            {
                Button2 = false;
                buttonIndexNum = 2;
                //theClient.Press_O(buttonIndexNum);
                pubimg = Asia;

                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }
            }
            else if (rndnum == 2 && Button2 == false)
            {
                BlinkButton();
            }
            else if (rndnum == 3 && Button3 == true)
            {
                Button3 = false;
                buttonIndexNum = 3;
                //theClient.Press_O(buttonIndexNum);
                pubimg = Africa;

                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }

            }
            else if (rndnum == 3 && Button3 == false)
            {
                BlinkButton();
            }
            else if (rndnum == 4 && Button4 == true)
            {
                Button4 = false;
                buttonIndexNum = 4;
                //theClient.Press_O(buttonIndexNum);
                pubimg = Oceania;

                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }

            }
            else if (rndnum == 4 && Button4 == false)
            {
                BlinkButton();
            }
            else if (rndnum == 5 && Button5 == true)
            {
                Button5 = false;
                buttonIndexNum = 5;
                //theClient.Press_O(buttonIndexNum);
                pubimg = Europe;

                if (isBlinking)
                    return;

                if (pubimg != null)
                {
                    isBlinking = true;
                    InvokeRepeating("ToggleState", startDelay, interval);
                }

            }
            else if (rndnum == 5 && Button5 == false)
            {
                BlinkButton();
            }

            if (Button0 == false && Button1 == false && Button2 == false && Button3 == false && Button4 == false && Button5 == false)
            {
                Button0 = true;
                Button1 = true;
                Button2 = true;
                Button3 = true;
                Button4 = true;
                Button5 = true;
            }
        }
        else
        {
            //theClient.GetDirectionData(out buttons);
            //switch (buttons)
            //{
            //    case "Zero":
            //        value = 0;
            //        break;
            //    case "One":
            //        value = 1;
            //        break;
            //    case "Two":
            //        value = 2;
            //        break;
            //    case "Three":
            //        value = 3;
            //        break;
            //    default:
            //        break;
            //}
            int randomscene = UnityEngine.Random.Range(0, 6);
            switch (randomscene)
            {
                case 0:
                    SceneManager.LoadScene("Seoul");
                    break;
                case 1:
                    SceneManager.LoadScene("Seoul");
                    break;
                case 2:
                    SceneManager.LoadScene("Seoul");
                    break;
                case 3:
                    SceneManager.LoadScene("Seoul");
                    break;
                case 4:
                    SceneManager.LoadScene("Seoul");
                    break;
                case 5:
                    SceneManager.LoadScene("Seoul");
                    break;
                default:
                    break;

            }
        }
    }
    public void ToggleState()
    {
        if (cb.normalColor == Color.white)
        {
            cb.normalColor = Color.yellow;
            pubimg.colors = cb;
        }
        else
        {
            cb.normalColor = Color.white;
            pubimg.colors = cb;
        }
        count++;
        if (count == num_of_blink_arrow)
        {
            CancelInvoke();
            blinkcnt++;

            if (rndnum == 0) noA++;
            else if (rndnum == 1) soA++;
            else if (rndnum == 2) Asi++;
            else if (rndnum == 3) Afr++;
            else if (rndnum == 4) Oce++;
            else Eur++;

            count = 0;
            isBlinking = false;
            Invoke("BlinkButton", timebetweenarrows);
        }
    }

}
///-----------------------------------------------------------------------------------
///-----------------------------------------------------------------------------------
/// UIVA Server - Unity Indie VRPN Adapter 
/// 
/// File: UIVA.cs
/// 
/// Description:
///     Each device has a UIVA_Device class, which contains data buffers and callbacks 
///     functions.
/// 
/// Author: 
///     Jia Wang (wangjia@wpi.edu)
///     Human Interaction in Virtual Enviroments (HIVE) Lab
///     Department of Computer Science
///     Worcester Polytechnic Institute
/// 
/// History: (1.0) 02/05/2011  by  Jia Wang           
///-----------------------------------------------------------------------------------
///-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vrpn;
using System.Threading;

namespace UIVA_Server
{
    class VRPN_ButtonServer
    {
        // Server
        ButtonRemote buttRemote;
        public int orderNumber = 5;
        public bool b_up;
        public bool b_down;
        public bool b_left;
        public bool b_right;

        public VRPN_ButtonServer(string ID)
        {
            buttRemote = new ButtonRemote(ID);
            buttRemote.ButtonChanged += new ButtonChangeEventHandler(EpocButtonChanged);
            buttRemote.MuteWarnings = true;
        }

        private void EpocButtonChanged(object sender, ButtonChangeEventArgs e)
        {
            switch (e.Button)
            {
                case 0: // Up arrow
                    if (e.IsPressed) { b_up = true; } else { b_up = false; }
                    break;
                case 1: // Down arrow
                    if (e.IsPressed) { b_down = true; } else { b_down = false; }
                    break;
                case 2: // Left arrow
                    if (e.IsPressed) { b_left = true; } else { b_left = false; }
                    break;
                case 3: // Right arrow
                    if (e.IsPressed) { b_right = true; } else { b_right = false; }
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            buttRemote.Update();
        }

        public int Simulate()
        {
            return orderNumber;
        }

        public String Encode()
        {
            String buttStr = "";
            // Uppercase for button press, lowercase for button release
            if (b_up) { buttStr = "0"; }
            else if (b_down) { buttStr = "1"; }
            else if (b_left) { buttStr = "2"; }
            else { buttStr = "3"; }
            return buttStr;
        }
    }

    class UIVA_ButtonServer
    {
        // Server
        ButtonServer buttServer;
        Connection vrpnConnection;
        int buttNums = 4;  // You can use the number of buttons as you need by chainging this value.

        public UIVA_ButtonServer()
        {
            vrpnConnection = Connection.CreateServerConnection(50555);// port number
            buttServer = new ButtonServer("button_test@localhost", vrpnConnection, 32);   // 마지막은 버튼 개수 
            buttServer.MuteWarnings = true;
        }

        public void WakeUpTest()
        {
            for (int i = 1; i < 7; i++)
            {
                Thread.Sleep(500);
                for (int j = 0; j < buttNums; j++)
                {
                    buttServer.Buttons[j] = true;
                    buttServer.Update();
                    vrpnConnection.Update();

                    buttServer.Buttons[j] = false;
                    buttServer.Update();
                    vrpnConnection.Update();
                }
                Console.WriteLine("UIVA_Server Test..." + i);
            }
            Console.WriteLine("UIVA_Server VRPN Connection Completed!");
        }

        /* Press */
        public void Press(int num)
        {
            buttServer.Buttons[num] = true;
            buttServer.Update();
            vrpnConnection.Update();
            Console.WriteLine(buttServer.Buttons[num]);
            Release(num); //바로 끄게 만들어서 표시되는데 오류가 없도록.
        }

        /* Release */
        public void Release(int num)
        {
            buttServer.Buttons[num] = false;
            buttServer.Update();
            vrpnConnection.Update();
            Console.WriteLine(buttServer.Buttons[num]);
        }

        /* Encode Epoc data to UIVA_Client */
        public String Encode()
        {
            String buttStr = "";
            return buttStr;
        }

    }

}
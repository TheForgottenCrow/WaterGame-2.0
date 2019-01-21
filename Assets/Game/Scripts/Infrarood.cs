using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Ultrasonic : MonoBehaviour
{
    //get the serial port
    SerialPort m_SerialPort;


    // Use this for initialization
    void Start()
    {
        //zoek voor de juiste COM (check in arduino code welke het is en pas de COM aan naar de gene die dr staat)
        m_SerialPort = new SerialPort("COM4", 9600);
        //arduino openen
        m_SerialPort.Open();
        m_SerialPort.DiscardInBuffer();
    }

    void Update()
    {
        //if statement die infrarood terug geeft 
        String read = m_SerialPort.ReadLine();
        if (read == "true")
        {
            Debug.Log("1");
        }
        else if (read == "false")
        {
            Debug.Log("0");
        }
    }
}

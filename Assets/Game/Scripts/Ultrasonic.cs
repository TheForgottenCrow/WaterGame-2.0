using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class Ultrasonic : MonoBehaviour
{
	[SerializeField] private SpawnerBlock m_SpawnerBlock;
    //get the serial port
    SerialPort m_SerialPort;


    // Use this for initialization
    void Start()
    {
        //zoek voor de juiste COM (check in arduino code welke het is en pas de COM aan naar de gene die dr staat)
        m_SerialPort = new SerialPort("COM6", 9600);
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
			m_SpawnerBlock.m_Interupted = true;
        }
        else if (read == "false")
        {
			m_SpawnerBlock.m_Interupted = false;
		}
    }
}

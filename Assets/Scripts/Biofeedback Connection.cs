using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO.Ports;
using System;

public class BiofeedbackConnection : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }
    private SerialPort serialPort = new SerialPort("COM3", 9600);
    [SerializeField] TMP_Text biofeedbackValue;
    public int emgValues;

    void Start()
    {
        try
        {
            serialPort.ReadTimeout = 100; 
            serialPort.Open();
            Debug.Log("Serial port opened successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to open serial port: " + ex.Message);
        }
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                if (serialPort.BytesToRead > 0)
                {
                    string data = serialPort.ReadLine().Trim();
                    int muscle_input;
                    if (int.TryParse(data, out muscle_input)) 
                    {
                        emgValues = muscle_input;
                        biofeedbackValue.text = muscle_input.ToString();
                    }
                    else
                    {
                        Debug.LogWarning("Received non-integer data: " + data);
                    }
                }
                else
                {
                    biofeedbackValue.text = "Not Connected";
                }
            }
            catch (TimeoutException)
            {
                Debug.LogWarning("Serial read timeout.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Serial read error: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("Serial port is closed.");
        }
    }
    public int ShareEMGValues()
    {
        return emgValues;
    }

    void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial port closed.");
        }
    }
}

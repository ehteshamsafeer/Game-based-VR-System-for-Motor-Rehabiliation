using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class snd_recv : MonoBehaviour
{
    public string serverIP = "127.0.0.1";
    public int serverPort = 12345;
    public RawImage displayImage;
    public Text messageText;  // Add a UI Text to display received strings

    private TcpClient client;
    private NetworkStream stream;
    private bool stop = false;

    void Start()
    {
        Application.runInBackground = true;
        ConnectToServer();
    }

    void Update()
    {
        if (client != null && client.Connected && stream.DataAvailable)
        {
            byte messageType = (byte)stream.ReadByte();
            if (messageType == 0x01)  // Image
            {
                HandleImageMessage();
            }
            else if (messageType == 0x02)  // String
            {
                HandleStringMessage();
            }
        }
    }

    void HandleImageMessage()
    {
        byte[] imageSizeBytes = new byte[4];
        if (stream.Read(imageSizeBytes, 0, 4) == 4)
        {
            int imageSize = BitConverter.ToInt32(imageSizeBytes, 0);
            imageSize = IPAddress.NetworkToHostOrder(imageSize);

            byte[] imageData = new byte[imageSize];
            int dataRead = 0;
            while (dataRead < imageSize)
            {
                dataRead += stream.Read(imageData, dataRead, imageSize - dataRead);
            }

            Texture2D tex = new Texture2D(2, 2);
            if (tex.LoadImage(imageData))
            {
                displayImage.texture = tex;
            }
        }
    }

    void HandleStringMessage()
    {
        byte[] messageSizeBytes = new byte[4];
        if (stream.Read(messageSizeBytes, 0, 4) == 4)
        {
            int messageSize = BitConverter.ToInt32(messageSizeBytes, 0);
            messageSize = IPAddress.NetworkToHostOrder(messageSize);

            byte[] messageData = new byte[messageSize];
            stream.Read(messageData, 0, messageSize);
            string message = System.Text.Encoding.UTF8.GetString(messageData);
            Debug.Log("Received message: " + message);
            // Update UI Text or handle the message as needed
            messageText.text = message;  // Assuming you have a Text UI component to display the text message
        }
    }
    void ConnectToServer()
    {
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            Debug.Log("Connected to server.");
        }
        catch (Exception e)
        {
            Debug.LogError("Socket error: " + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        stop = true;
        if (stream != null)
        {
            stream.Close();
        }
        if (client != null)
        {
            client.Close();
        }
    }
}

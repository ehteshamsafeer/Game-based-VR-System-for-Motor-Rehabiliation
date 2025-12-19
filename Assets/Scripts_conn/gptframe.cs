using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class gptframe : MonoBehaviour
{
    public string serverIP = "127.0.0.1";
    public int serverPort = 12345;
    public RawImage displayImage;

    private TcpClient client;
    private NetworkStream stream;
    private byte[] imageData = new byte[0];
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
            if (stream.CanRead)
            {
                byte[] imageSizeBytes = new byte[4];
                int bytesRead = stream.Read(imageSizeBytes, 0, 4);
                if (bytesRead == 4)
                {
                    // Ensure we're interpreting the bytes as big-endian
                    int imageSize = BitConverter.ToInt32(imageSizeBytes, 0);
                    imageSize = IPAddress.NetworkToHostOrder(imageSize);
                    Debug.Log(imageSize);

                    if (imageSize > 0)
                    {
                        imageData = new byte[imageSize];
                        int dataRead = 0;
                        while (dataRead < imageSize)
                        {
                            dataRead += stream.Read(imageData, dataRead, imageSize - dataRead);
                        }
                        Debug.Log("imgrcvd");

                        // Apply the received data as a texture
                        Texture2D tex = new Texture2D(2, 2);
                        File.WriteAllBytes("test.jpg", imageData);
                        if (tex.LoadImage(imageData))
                        {
                            //GetComponent<Renderer>().material.mainTexture = tex;
                            Debug.Log("img rndrd");
                            displayImage.texture = tex;
                            print("Size is " + tex.width + " by " + tex.height);
                        }
                    }
                }
            }
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

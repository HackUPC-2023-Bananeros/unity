using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPClient : MonoBehaviour
{
    [SerializeField] private string serverIp; // dirección IP del servidor 172.200.200.20
    [SerializeField] private int serverPort; // puerto del servidor 7000

    private UdpClient udpClient;
    private IPEndPoint serverEndPoint;
    private string lastReceivedMessage;

    // Define el evento OnMessageReceived
    public event Action<string> OnMessageReceived;

    public void Start()
    {
        udpClient = new UdpClient();
        serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

        print("Client started");

        udpClient.BeginReceive(ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        byte[] data = udpClient.EndReceive(ar, ref serverEndPoint);
        lastReceivedMessage = Encoding.ASCII.GetString(data);

        udpClient.BeginReceive(ReceiveCallback, null);
        //print("Received data from server: " + lastReceivedMessage);

        // Dispara el evento OnMessageReceived
        OnMessageReceived?.Invoke(lastReceivedMessage);
    }

    public void SendData(string message)
    {
        byte[] data = Encoding.ASCII.GetBytes(message);
        udpClient.Send(data, data.Length, serverEndPoint);
        print("Sent data to server: " + message);
    }

    private void OnApplicationQuit()
    {
        udpClient.Close();
        print("Client closed");
    }

    // Getter para la última respuesta recibida
    public string GetLastReceivedMessage()
    {
        return lastReceivedMessage;
    }
}

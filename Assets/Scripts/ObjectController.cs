using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public UDPClient udpClient;
    private Vector3 currentPosition;

    void Start()
    {
        // Obtiene la posición inicial del objeto
        currentPosition = transform.position;
    }

    void OnEnable()
    {
        // Se suscribe al evento OnMessageReceived del cliente UDP
        udpClient.OnMessageReceived += UpdatePosition;
    }

    void OnDisable()
    {
        // Se desuscribe del evento OnMessageReceived del cliente UDP
        udpClient.OnMessageReceived -= UpdatePosition;
    }

    void UpdatePosition(string message)
    {
        // Divide el mensaje recibido en coordenadas X, Y y Z
        string[] coordinates = message.Split(',');
        float x = float.Parse(coordinates[0]);
        float y = float.Parse(coordinates[1]);
        float z = float.Parse(coordinates[2]);

        // Actualiza la posición del objeto
        currentPosition = new Vector3(x, y, z);
    }

    void Update()
    {
        // Actualiza la posición del objeto en cada frame
        transform.position = currentPosition;
    }
}


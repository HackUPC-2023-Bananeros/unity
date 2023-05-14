using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Button paddleButton;
    [SerializeField] private GameObject player;

    private UDPClient udpClient;
    private Vector3 newPosition;
    private PlayerInfo playerInfo = new PlayerInfo();

    private int clicks;
    private bool messageReceived;

    private void Start()
    {
        clicks = 0;
        messageReceived = false;

        udpClient = GameObject.FindObjectOfType<UDPClient>();
        udpClient.OnMessageReceived += OnMessageReceived;
    }

    private void Update()
    {
        if(messageReceived)
        {
            //player.transform.LookAt(player.transform.position + newPosition);
            player.transform.position -= newPosition * Time.deltaTime * 1000;
            player.transform.position.Normalize();
            print(player.transform.position);
            messageReceived = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position += newPosition * 1000;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        string jsonData;
        if(clicks==0) 
        {
            playerInfo.type = 6;
            playerInfo.button_pressed = 0;
            jsonData = JsonUtility.ToJson(playerInfo);
            udpClient.SendData(jsonData);
        }

        playerInfo.button_pressed = 1;
        playerInfo.type = 4;

        jsonData = JsonUtility.ToJson(playerInfo);
        udpClient.SendData(jsonData);

        clicks++;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerInfo.button_pressed = 0;
        playerInfo.type = 4;

        string jsonData = JsonUtility.ToJson(playerInfo);
        udpClient.SendData(jsonData);
    }

    private void OnMessageReceived(string message)
    {
        MovementData movementData = JsonUtility.FromJson<MovementData>(message);
        newPosition = new Vector3(movementData.AxisX, movementData.AxisY, movementData.AxisZ);
        messageReceived = true;
    }
}

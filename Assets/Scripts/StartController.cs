using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartController : MonoBehaviour
{
    [SerializeField] private Button paddleButton;

    private UDPClient udpClient;
    private float time = 0.0f;
    private PlayerInfo playerInfo = new PlayerInfo();

    private int clicks;

    private void Start()
    {
        paddleButton.onClick.AddListener(() => onClick(null));
        udpClient = GameObject.FindObjectOfType<UDPClient>();
        udpClient.OnMessageReceived += OnMessageReceived;
    }


    public void onClick(PointerEventData eventData)
    {
        playerInfo.type = 1;
        playerInfo.button_pressed = 0;
        string jsonData = JsonUtility.ToJson(playerInfo);
        udpClient.SendData(jsonData);
    }

    private void OnMessageReceived(string message)
    {
        TimerInfo timerData = JsonUtility.FromJson<TimerInfo>(message);
        time = timerData.time;
        print(time);
        PlayerPrefs.SetFloat("Time", time);

    }
}


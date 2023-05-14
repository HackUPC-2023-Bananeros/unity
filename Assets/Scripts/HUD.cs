using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Button up_button;
    [SerializeField] private Button down_button;
    [SerializeField] private Button left_button;
    [SerializeField] private Button right_button;
    [SerializeField] private Button paddle_button;

    // Start is called before the first frame update
    void Start()
    {
        up_button.gameObject.SetActive(false);
        down_button.gameObject.SetActive(false);
        left_button.gameObject.SetActive(false);
        right_button.gameObject.SetActive(false);
        paddle_button.gameObject.SetActive(false);
    }

    public void ShowDPad()
    {
        up_button.gameObject.SetActive(true);
        down_button.gameObject.SetActive(true);
        left_button.gameObject.SetActive(true);
        right_button.gameObject.SetActive(true);
        paddle_button.gameObject.SetActive(false);
    }

    public void ShowPaddle()
    {
        up_button.gameObject.SetActive(false);
        down_button.gameObject.SetActive(false);
        left_button.gameObject.SetActive(false);
        right_button.gameObject.SetActive(false);
        paddle_button.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

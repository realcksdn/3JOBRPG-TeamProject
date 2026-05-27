using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashColBox : MonoBehaviour
{
    public Image UI;

    void Start()
    {
        UI = GetComponent<Image>();
    }

    void Update()
    {
        UI.fillAmount = PlayerControler.player.dashCol / PlayerControler.player.dashColtime;
    }
}

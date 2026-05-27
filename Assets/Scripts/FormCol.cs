using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormCol : MonoBehaviour
{
    public Image UI;

    void Start()
    {
        UI = GetComponent<Image>();
    }

    void Update()
    {
        UI.fillAmount = PlayerControler.player.col / PlayerControler.player.coltime;
    }
}

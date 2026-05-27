using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormUIUI : MonoBehaviour
{
    public Image UI;
    public Sprite form1;
    public Sprite form2;
    public Sprite form3;

    void Start()
    {
        UI = GetComponent<Image>();
    }

    void Update()
    {
        switch (PlayerControler.player.form)
        {
            case 1:
                UI.sprite = form1;
                break;
            case 2:
                UI.sprite = form2;
                break;
            case 3:
                UI.sprite = form3;
                break;
        }
    }
}

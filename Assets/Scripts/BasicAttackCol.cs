using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttackCol : MonoBehaviour
{
    public Image UI;

    void Start()
    {
        UI = GetComponent<Image>();
    }

    void Update()
    {
        switch (PlayerControler.player.form)
        {
            case 1:
                UI.fillAmount = PlayerControler.player.sword_basic_col / PlayerControler.player.sword_basic_coltime;
                break;
            case 2:
                UI.fillAmount = PlayerControler.player.magic_basic_col / PlayerControler.player.magic_basic_coltime;
                break;
            case 3:
                UI.fillAmount = PlayerControler.player.bullet_basic_col / PlayerControler.player.bullet_basic_coltime;
                break;
        }
    }
}

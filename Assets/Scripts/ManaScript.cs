using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaScript : MonoBehaviour
{
    public Image UI;

    void Start()
    {

        UI = GetComponent<Image>();
    }

    void Update()
    {
        UI.fillAmount = GameManager.gameData.Mana / GameManager.gameData.MaxMana;
    }
}

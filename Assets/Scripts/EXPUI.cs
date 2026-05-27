using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPUI : MonoBehaviour
{
    public Image UI;

    void Start()
    {
        UI = GetComponent<Image>();
    }

    void Update()
    {
        UI.fillAmount = GameManager.gameData.haveExp / GameManager.gameData.needExp;
    }
}

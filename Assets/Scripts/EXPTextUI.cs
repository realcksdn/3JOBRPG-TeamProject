using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPTextUI : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = $"·¹º§:{GameManager.gameData.lev} exp:{GameManager.gameData.haveExp}/{GameManager.gameData.needExp}";
    }
}

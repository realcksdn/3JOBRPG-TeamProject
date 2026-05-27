using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameData;

    public float hp;
    public float maxhp;
    public float shild;
    public float damage;
    public float Mana;
    public float MaxMana;

    public float needExp;
    public float haveExp;
    public int lev;

    public Text HPUI;

    public static bool isGameStop = false;

    public float lessDamage;

    public int sceneNum;

    public int HPPS;
    public int regen;

    public int MPPS;
    public float mpRegen;

    public static GameManager instance;

    private void Awake()
    {
        if (gameData == null) //教臂沛
        {
            gameData = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (haveExp >= needExp)
            LevelUp();

        if (hp <= 0)
        {
            OnDie();
            hp = maxhp;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Menew();
    }

    public void OnHit(float damage)
    {
        if (PlayerControler.player.none <= 0)
        {
            if (shild > damage)
                shild -= damage;
            else
            {
                lessDamage = damage - shild;
                shild -= shild;
                hp -= damage;
            }
        }
    }

    public void GetExp(float exp)
    {
        haveExp += exp;
    }

    public void LevelUp()
    {
        haveExp -= needExp;
        lev += 1;
        needExp += 100 * lev;
    }

    void OnDie()
    {
        SceneManager.LoadScene("EndScene");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Panel.panel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isGameStop = false;
    }

    public void Pause()
    {
        Panel.panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isGameStop = true;
    }

    public void ManaGauge(float manasum)
    {
        Mana -= manasum;
    }

    public void Menew()
    {
        if (isGameStop)
        {
            Resume();
            Debug.Log("坷具福 荤惯");
        }
        else
        {
            Pause();
            Debug.Log("具富");
        }
    }

    public void Regeneration()
    {
        if ((maxhp - hp) < regen)
        {
            hp = maxhp;
            HPPS -= 1;
        }
        else
        {
            hp += regen;
            HPPS -= 1;
        }
    }

    public void MPRegeneration()
    {
        if ((MaxMana - Mana) < mpRegen)
        {
            Mana = MaxMana;
            MPPS -= 1;
        }
        else
        {
            Mana += mpRegen;
            MPPS -= 1;
        }
    }
}

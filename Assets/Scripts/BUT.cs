using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BUT : MonoBehaviour
{
    public int scene;

    public void Butten()
    {
        SceneManager.LoadScene(CamControler.cam.scene);
        Time.timeScale = 1f;
    }
    public void OnClick3()
    {
        scene = 4;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    public void OnClick1()
    {
        scene = 2;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    public void OnClick2()
    {
        scene = 3;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    public void OnClick()
    {
        SceneManager.LoadScene("SelectScene");
        Time.timeScale = 0f;
    }
    public void returnMain()
    {
        SceneManager.LoadScene("StartScenes");
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        GameManager.gameData.Resume();
    }
}

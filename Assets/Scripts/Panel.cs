using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Panel : MonoBehaviour
{
    public static Panel panel;

    private void Awake()
    {
        if (panel == null) //ΩÃ±€≈Ê
        {
            panel = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        gameObject.SetActive(false);

    }
}

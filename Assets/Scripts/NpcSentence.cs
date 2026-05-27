using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    public string[] sentence;
    public Transform chatTr;
    public GameObject chatBoxPrefab;
    private void Start()
    {
        
    }
    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        //go.GetComponent<ChatSystem>().Ondialogue(sentence);

    }
    private void OnMouseDown()
    {
        TalkNpc();
    }
    //https://www.youtube.com/watch?v=WOmJ4ZPSsCk&t=41s
}

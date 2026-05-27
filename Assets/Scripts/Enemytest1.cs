using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytest1 : EnemtTest
{
    public float hp = 100f;

    void Update()
    {
        player = PlayerControler.player.transform;

        if (hp <= 0)
        {
            GameManager.gameData.GetExp(30);
            Destroy(gameObject);
        }
        EnemyAI();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") //적 맞추면 총알 삭제 ~
        {
            hp -= 10 * GameManager.gameData.lev;
        }
        if (collision.gameObject.tag == "Sword_Basic") //적 맞추면 총알 삭제 ~
        {
            hp -= 20 * GameManager.gameData.lev;
        }
        if (collision.gameObject.tag == "Magic") //적 맞추면 총알 삭제 ~
        {
            hp -= 30 * GameManager.gameData.lev;
        }
    }
}

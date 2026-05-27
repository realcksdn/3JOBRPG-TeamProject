using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 10.0f;

    Rigidbody2D rigid;

    PlayerControler playerControler;

    float bulletDir;

    SpriteRenderer sprite;

    private void Start()
    {
        playerControler = PlayerControler.player;
        bulletDir = playerControler.dir;
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) //적 맞추면 총알 삭제 ~
        {
            //총알 삭제
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(bulletDir, 0, 0) * playerControler.bulletSpeed / 50);

        switch (bulletDir)
        {
            case 1:
                sprite.flipX = false;
                break;
            case -1:
                sprite.flipX = true;
                break;
        }
    }
}

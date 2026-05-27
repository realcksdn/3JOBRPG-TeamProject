using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    // 이거 쓸데없으니까 BulletScript 어태치해라

    public float speed = 5.0f;
    public float lifeTime = 10.0f;

    private Rigidbody2D rigid;

    PlayerControler playerControler;

    float magicDir;

    SpriteRenderer sprite;

    void Start()
    {
        playerControler = PlayerControler.player;
        magicDir = playerControler.dir;
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
        transform.Translate(new Vector3(magicDir, 0, 0) * playerControler.magicSpeed / 50);

        switch (magicDir)
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

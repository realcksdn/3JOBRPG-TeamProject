using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffect : MonoBehaviour
{
    int bulletDir;
    SpriteRenderer sprite;

    PlayerControler playerControler;

    private void Start()
    {
        playerControler = PlayerControler.player;
        bulletDir = playerControler.dir;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerControler.IsAttack) //tlqkf 변수가 true면 아래 함수 실행시킴 개추
        {
            StartCoroutine("DestroyObject");

            playerControler.IsAttack = false;
        }
        switch (bulletDir) //진성아 좌우 반전이 안된다 화이팅응원한다.
        {
            case 1:
                sprite.flipX = true;
                break;
            case -1:
                sprite.flipX = false;
                break;
        }

    }

    IEnumerator DestroyObject() //이걸로 이펙트 0.2초 뒤에 삭제
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }
}

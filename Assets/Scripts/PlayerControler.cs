using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler player;

    public float speed; //캐릭터 스펙

    public float jumpPW;

    public float playerMove;

    [SerializeField] // 시간 절약(조용하)
    private GameObject[] bullet; //모든 공격 모션 블릿으로 돌려쓰자 case 써서

    public int form;

    public float bulletSpeed;

    public float magicSpeed;

    public int dir;

    public Transform rfwaf;

    public SpriteRenderer sprite;

    //쿨타임
    public float sword_basic_col;
    public float sword_basic_coltime;
    public float bullet_basic_col;
    public float bullet_basic_coltime;
    public float magic_basic_col;
    public float magic_basic_coltime;
    public float dashCol;
    public float dashColtime;
    public float col;
    public float coltime;
    public float reload;
    public int left_bullet;
    public int full_bullet;
    //점프(레이케스트 이용)
    public float jumpForce = 5f; // 점프 힘
    public LayerMask groundLayer; // 바닥 레이어
    public Transform groundCheck; // 바닥 체크 위치
    public float groundCheckDistance = 0.2f; // 체크할 거리

    private Rigidbody2D rb;

    public float dashDistance;

    public float none;

    public Animator anim;

    public bool IsAttack;

    private void Awake()
    {
        if (player == null) //싱글톤
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else
            Destroy(gameObject);
        playerMove = 1;
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        playerMove = Input.GetAxis("Horizontal"); /** speed * Time.deltaTime;*/ //좌우이동

        sword_basic_col -= Time.deltaTime;
        bullet_basic_col -= Time.deltaTime;
        magic_basic_col -= Time.deltaTime;

        //if (playerMove > 0)
        //    {
        //    playerMove = speed * Time.deltaTime;
        //    }
        //if (playerMove < 0)
        //    {
        //    playerMove = -speed * Time.deltaTime;
        //    }
        // 레이캐스트를 사용하여 바닥에 닿아있는지 확인

        bool isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance, Color.red);
        if (isGrounded && Input.GetButtonDown("Jump")) //점프 입력
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) //모든 폼 공격하는 곳
        {
            Attack();
        }

        if (GameManager.gameData.HPPS > 0 && Input.GetKeyDown(KeyCode.F) && GameManager.gameData.maxhp != GameManager.gameData.hp)
            GameManager.gameData.Regeneration();

        if (GameManager.gameData.MPPS > 0 && Input.GetKeyDown(KeyCode.G) && GameManager.gameData.MaxMana != GameManager.gameData.Mana)
            GameManager.gameData.MPRegeneration();

        if (dashCol <= 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3(dashDistance * dir, 0, 0);
            dashCol = dashColtime;
            none = 0.5f;
        }

        if (col <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && form != 1)
            {
                form = 1;
                col = coltime;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && form != 2)
            {
                form = 2;
                col = coltime;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && form != 3)
            {
                form = 3;
                col = coltime;
            }
        }

        if (col > 0)
            col -= Time.deltaTime;

        if (dir > 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        if (dashCol > 0)
            dashCol -= Time.deltaTime;

        if (none > 0)
        {
            none -= Time.deltaTime;
            gameObject.tag = "nonetarget";
            sprite.color = new Color(1, 1, 1, 0.5f);
        }

        else
        {
            gameObject.tag = "Player";
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void Attack()
    {
        switch (form)
        {
            case 1: //  검 공격하는 폼
                if (sword_basic_col <= 0)
                {
                    sword_basic_col = sword_basic_coltime;
                    anim.SetTrigger("IsAttack");

                    IsAttack = true;

                    Instantiate(bullet[0], transform.position, transform.rotation);
                }
                break;

            case 2: // 마법쏘는 폼
                if (magic_basic_col <= 0 && GameManager.gameData.Mana >= 50)
                {
                    Instantiate(bullet[1], transform.position, transform.rotation);
                    GameManager.gameData.ManaGauge(50);
                    magic_basic_col = magic_basic_coltime;
                }
                break;

            case 3: // 총알쏘는 폼
                if (bullet_basic_col <= 0 && left_bullet > 0)
                {
                    Instantiate(bullet[2], transform.position, transform.rotation);

                    bullet_basic_col = bullet_basic_coltime;
                    left_bullet -= 1;
                }
                else if (left_bullet <= 0 && GameManager.gameData.Mana >= 100)
                {
                    bullet_basic_col = reload;
                    left_bullet = full_bullet;
                    GameManager.gameData.ManaGauge(100);
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(playerMove, 0, 0) * speed * Time.deltaTime); //좌우 물리력

        if (playerMove > 0)
        {
            dir = 1;
            anim.SetBool("IsRun", true);
        }
        if (playerMove < 0)
        {
            dir = -1;
            anim.SetBool("IsRun", true);
        }
        if (playerMove == 0)
        {
            anim.SetBool("IsRun", false);
        }
    }

    private void Jump() //점프 물리력
    {
        //rigid.AddForce(Vector3.up * jumpPW, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemtTest : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float moveSpeed = 2f; // 적의 이동 속도
    public float attackRange = 0.5f; // 공격 범위
    public float attackCooldown = 1f; // 공격 쿨다운 시간
    private float attackTimer;
    public float trackingdistance = 10;

    public void EnemyAI()
    {
        // 플레이어와의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 공격 쿨다운 타이머 업데이트
        attackTimer -= Time.deltaTime;

        // 플레이어가 공격 범위 내에 있으면 공격
        if (distanceToPlayer <= attackRange)
        {
            if (attackTimer <= 0f)
            {
                GameManager.gameData.OnHit(30f);
                attackTimer = attackCooldown;
            }
        }
        else
        {
            if (distanceToPlayer < trackingdistance)
                MoveTowardsPlayer(); // 플레이어가 공격 범위를 벗어나면 따라가기
        }
    }

    public void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}

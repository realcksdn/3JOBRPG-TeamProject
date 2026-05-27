using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CamControler : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float smoothSpeed = 0.125f; // 카메라 움직임 부드러움
    public Vector3 offset; // 카메라와 플레이어 사이의 오프셋

    public static CamControler cam;

    public int scene;

    private void Awake()
    {
        if (cam == null) //싱글톤
        {
            cam = this;

        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    void FixedUpdate()
    {
        player = PlayerControler.player.transform;
        Vector3 desiredPosition = player.position + offset; // 원하는 위치
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 부드러운 이동
        smoothedPosition.z = transform.position.z;
        transform.position = smoothedPosition; // 카메라 위치 설정
    }
}

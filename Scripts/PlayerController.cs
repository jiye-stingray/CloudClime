using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene을 사용하는데 필요하다

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    [SerializeField]
    float maxWalkforce = 2.0f;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //점프한다
        if (Input.GetKeyDown(KeyCode.Space)&& rigid2D.velocity.y == 0)
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어의 속도
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        //스피드 제한
        if(speedx < maxWalkforce)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        //움직이는 방향에 따라 전환한다.
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        animator.speed = speedx / 2.0f;

        //플레이어가 화면 밖으로 나왔다면 처음부터
        if (rigid2D.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
    //골 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene�� ����ϴµ� �ʿ��ϴ�

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
        //�����Ѵ�
        if (Input.GetKeyDown(KeyCode.Space)&& rigid2D.velocity.y == 0)
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        //���ǵ� ����
        if(speedx < maxWalkforce)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        //�����̴� ���⿡ ���� ��ȯ�Ѵ�.
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        animator.speed = speedx / 2.0f;

        //�÷��̾ ȭ�� ������ ���Դٸ� ó������
        if (rigid2D.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
    //�� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}

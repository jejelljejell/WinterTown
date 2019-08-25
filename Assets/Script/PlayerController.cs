using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    private Rigidbody2D rigid;

    bool isGround;
    public Transform pos;
    public float checkRadius;
    public LayerMask isLayer;

    int jumpCnt;
    int jumpCount = 2;

    public Animator animator;

    public bool isLadder;

    public bool onJumper = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, isLayer);

        Walk();

        if (isLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, ver * speed);
        }
        else
        {
            Jump();
            rigid.gravityScale = 6f;
        }
    }
    /*
    // 카메라 이동
    private void OutlineRestrict()
    {

        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0.05f) worldpos.x = 0.05f;
        if (worldpos.y < 0.05f) worldpos.y = 0.05f;
        if (worldpos.x > 0.95f) worldpos.x = 0.95f;
        if (worldpos.y > 0.95f) worldpos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
    */
    private void Jump()
    {
        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            animator.SetTrigger("jump");
            rigid.velocity = Vector2.up * jumpPower;
            // Vetcor2.up = (0,1)
        }

        //공중점프 가능
        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            rigid.velocity = Vector2.up * jumpPower;
        }

        //점프 후 착지
        if (isGround && jumpCnt != jumpCount)
        {
            rigid.velocity = Vector2.zero; //지면에 닿는 순간 가속도 0
            animator.SetTrigger("isground");
        }

        //스페이스바 올라갈때 jumpcnt 1 감소
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCnt--;
        }

        //땅에 닿으면 jumpcnt 초기화
        if (isGround)
            jumpCnt = jumpCount;

        //점프대
        if (onJumper)
        {
            rigid.AddForce(new Vector3(0, 3, 0) * speed, ForceMode2D.Impulse);
            onJumper = false;
        }
    }

    private void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);

        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           
            animator.SetBool("walk", true);
            animator.SetBool("walkNIdle", true);
        }
        else if(horizontal<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

            animator.SetBool("walk", true);
            animator.SetBool("walkNIdle", true);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("walkNIdle", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //사다리 오르기
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        //물이 닿으면 처음으로
        if (collision.CompareTag("water"))
        {
            ScoreManager.score = 0;
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //문 도착해서 위화살표 누르면 씬 전환
        if(collision.CompareTag("door") && Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("NextGameScene");
        }
        //종료 문 도착해서 위화살표 누르면 씬 전환
        if (collision.CompareTag("exitdoor") && Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }

    //점프대
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Jumper")
        {
            onJumper = true;
        }
    }


}

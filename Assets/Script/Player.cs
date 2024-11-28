using UnityEngine;

public class Player : MonoBehaviour
{
    //플레이어 스피드
    [SerializeField]
    private float speed = 5f;
    
    //플레이어 목숨
    private int hp = 3;
    public int Hp { set { hp = value; } get { return hp; } }

    //상하 좌우 움직임 제어
    private float LeftRight = 0F;
    private float upDown = 0F;
    
    //플레이어 vector값
    private  Vector3 pos = Vector3.zero;


    [SerializeField]
    private SkillData[] skillDB;
    public SkillData[] SkillDB { set { skillDB = value; } }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //플레이어 충돌 코드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tri"+collision.gameObject.name);
    }

    //플레이어 움직임 제어

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        upDown = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        pos.x += LeftRight;
        pos.y += upDown;
        transform.position = pos;
    }


    //공격 패턴 -> 배리어 공격, 미사일, 운석, 슬라이스 공격

}

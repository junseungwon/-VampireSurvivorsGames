using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    //플레이어 스피드
    [SerializeField]
    private float speed = 5f;
    public float Speed { set { speed = value; } get { return speed; } }

    //플레이어 목숨
    private float hp = 3;
    public float Hp { set { hp = value; } get { return hp; } }

    //상하 좌우 움직임 제어
    private float LeftRight = 0F;
    private float upDown = 0F;
    
    //플레이어 vector값
    private  Vector3 pos = Vector3.zero;


    [SerializeField]
    private PlayerSkill skill = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
        skill.AddSkill(PlayerSkill.SkillType.Barrier);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //플레이어 충돌 코드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("tri"+collision.gameObject.name);
    }

    //플레이어 움직임 제어

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        upDown = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        pos.x += LeftRight;
        pos.y += upDown;
        player.transform.position = pos;
    }


}

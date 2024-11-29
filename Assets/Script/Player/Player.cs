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
    public float Hp { set { hp = value; if (hp == 0) PlayerDead(); } get { return hp; } }

    //상하 좌우 움직임 제어
    private float LeftRight = 0F;
    private float upDown = 0F;

    //플레이어 vector값
    private Vector3 pos = Vector3.zero;


    [SerializeField]
    private PlayerSkill skill = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
        
        //기본 공격
        skill.AddSkill((int)SkillType.Slice);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //플레이어 충돌 코드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //아이템 먹을 때
        if (collision.gameObject.layer == (int)LayerName.ItemBox)
        {
            //박스 비활성화 후에 박스 오픈
            collision.gameObject.SetActive(false);
            OpenItemBox();
        }
    }

    //플레이어 움직임 제어

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        upDown = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        pos.x += LeftRight;
        pos.y += upDown;
        player.transform.position = pos;
    }

    private void PlayerDead()
    {
        ResetInform();
    }
    //아이템 오픈을 실행함
    //랜덤 아이템을 획득함
    private void OpenItemBox()
    {
        int randomNum = Random.Range(0, 3);
        Debug.Log($"박스를 획득하셨습니다. {randomNum}");
        skill.AddSkill(randomNum);
    }

    //체력이랑 속도를 reset 그리고 플레이어 위치 초기화 pos값 초기화 스킬도 초기화
    private void ResetInform()
    {
        hp = 3;
        speed = 5f;
        player.transform.position = Vector3.zero;
        pos = Vector3.zero;
        skill.SkillsReset();
    }
}
public enum LayerName
{
    Monster = 3, Attack = 6, Player = 7, ItemBox = 8
    //3 6 7 8
}


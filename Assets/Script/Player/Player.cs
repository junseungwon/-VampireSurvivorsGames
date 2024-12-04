using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class Player : Agent
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

    [SerializeField]
    private GameManager gameManager = null;

    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

            //박스를 먹으면 보상추가
            AddReward(1);
        }
    }

    //플레이어 움직임 제어

    private void PlayerDead()
    {
        //죽으면 보상 -1
        AddReward(-1);
        Debug.Log("죽음 재시작");
        EndEpisode();
    }
    //아이템 오픈을 실행함
    //랜덤 아이템을 획득함
    private void OpenItemBox()
    {
        int randomNum = Random.Range(0, 3);
        skill.AddSkill(randomNum);
    }

    //체력이랑 속도를 reset 그리고 플레이어 위치 초기화 pos값 초기화 스킬도 초기화
    private void ResetInform()
    {
        hp = 3;
        speed = 5f;
        player.transform.localPosition = Vector3.zero;
        pos = Vector3.zero;

        //스킬들 리셋
        skill.SkillsReset();

        //몬스터랑 박스도 리셋
        gameManager.ResetSetting();
    }

    //에피소드 시작
    public override void OnEpisodeBegin()
    {
        //정보들 초기화
        ResetInform();
        //기본 공격
        skill.AddSkill((int)SkillType.Slice);
    }

    //입력받을 경우
    public override void OnActionReceived(ActionBuffers actions)
    {
        upDown = actions.ContinuousActions[1];
        LeftRight = actions.ContinuousActions[0];
    }

    //움직임
    private void PlayerMove()
    {
        pos.x += LeftRight * Time.deltaTime * speed;
        pos.y += upDown * Time.deltaTime * speed;

        if (pos.x > 20) pos.x = 20;
        if (pos.x < -20) pos.x = -20;
        if (pos.y > 20) pos.y = 20;
        if (pos.y < -20) pos.y = -20;
        player.transform.localPosition = pos;
    }

    //직접 입력
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continueAction = actionsOut.ContinuousActions;
        continueAction[0] = Input.GetAxis("Horizontal");
        continueAction[1] = Input.GetAxis("Vertical");
        upDown = continueAction[1];
        LeftRight = continueAction[0];
    }
}
public enum LayerName
{
    Monster = 3, Attack = 6, Player = 7, ItemBox = 8
    //3 6 7 8
}


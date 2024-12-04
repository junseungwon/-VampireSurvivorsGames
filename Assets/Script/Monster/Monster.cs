using Unity.MLAgents;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData monsterData;
    public MonsterData MonsterData { set { monsterData = value; } }


    [SerializeField]
    private Player player = null;


    //겜 매니져
    [SerializeField]
    private GameManager gameManager = null;

    //위치값
    private Vector3 pos = Vector3.zero;

    //몬스터 쿨타임
    public float attackCool = 0f;

    //몬스터 속도
    public float speed = 0f;

    //몬스터 생명령
    public float hp = 3f;
    private void Update()
    {
        MoveToPlayer();
    }

    //플레이어한테 이동
    private void MoveToPlayer()
    {
        transform.position += (player.transform.position - transform.position) * monsterData.MoveSpeed * Time.deltaTime;
    }

    //trigger로 플레이어와 충돌 했을 경우
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackCool < 0.001f && collision.gameObject.layer == 7)
        {
            //attack판정
            Debug.Log("attack");

            //플레이어한테 보상을 삭제
            player.GetComponent<Agent>().AddReward(-0.5f);
            player.GetComponent<Player>().Hp -= 1;
            attackCool = 1;
        }
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("쿨타임중");
            attackCool -= speed*Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("벗어남");
            attackCool = 0f;
        }
    }

    
    //몬스터 정보를 리셋
    public void ResetSetting()
    {
        attackCool = 0f;
        hp = monsterData.MonsterHp;
        this.gameObject.SetActive(false);
    }

    //몬스터가 데미지를 입음
    public void HitDamage(float num)
    {
        hp -= num;
        player.AddReward(0.05f);
        //hp가 0보다 작아지면 몬스터가 죽었다고 판단하고 gamemanager에다가 죽었다고 보냄 그리고 리셋
        if (hp <= 0f)
        {
            attackCool = 0f;
            hp = monsterData.MonsterHp;
            gameManager.DeadMonster(this.gameObject);
        }
    }
}
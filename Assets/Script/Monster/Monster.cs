using Unity.MLAgents;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData monsterData;
    public MonsterData MonsterData { set { monsterData = value; } }


    [SerializeField]
    private Player player = null;


    //�� �Ŵ���
    [SerializeField]
    private GameManager gameManager = null;

    //��ġ��
    private Vector3 pos = Vector3.zero;

    //���� ��Ÿ��
    public float attackCool = 0f;

    //���� �ӵ�
    public float speed = 0f;

    //���� �����
    public float hp = 3f;
    private void Update()
    {
        MoveToPlayer();
    }

    //�÷��̾����� �̵�
    private void MoveToPlayer()
    {
        transform.position += (player.transform.position - transform.position) * monsterData.MoveSpeed * Time.deltaTime;
    }

    //trigger�� �÷��̾�� �浹 ���� ���
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackCool < 0.001f && collision.gameObject.layer == 7)
        {
            //attack����
            Debug.Log("attack");

            //�÷��̾����� ������ ����
            player.GetComponent<Agent>().AddReward(-0.5f);
            player.GetComponent<Player>().Hp -= 1;
            attackCool = 1;
        }
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("��Ÿ����");
            attackCool -= speed*Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("���");
            attackCool = 0f;
        }
    }

    
    //���� ������ ����
    public void ResetSetting()
    {
        attackCool = 0f;
        hp = monsterData.MonsterHp;
        this.gameObject.SetActive(false);
    }

    //���Ͱ� �������� ����
    public void HitDamage(float num)
    {
        hp -= num;
        player.AddReward(0.05f);
        //hp�� 0���� �۾����� ���Ͱ� �׾��ٰ� �Ǵ��ϰ� gamemanager���ٰ� �׾��ٰ� ���� �׸��� ����
        if (hp <= 0f)
        {
            attackCool = 0f;
            hp = monsterData.MonsterHp;
            gameManager.DeadMonster(this.gameObject);
        }
    }
}
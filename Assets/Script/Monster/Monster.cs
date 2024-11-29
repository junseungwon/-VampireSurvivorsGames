using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData monsterData;
    public MonsterData MonsterData { set { monsterData = value; } }

    private Vector3 pos = Vector3.zero;

    public float attackCool = 0f;
    public float speed = 0f;
    private void Update()
    {
        MoveToPlayer();
    }

    //플레이어한테 이동
    private void MoveToPlayer()
    {
        transform.position += (GameManager.instance.player.transform.position - transform.position) * monsterData.MoveSpeed * Time.deltaTime;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackCool < 0.001f && collision.gameObject.layer == 7)
        {
            //attack판정
            Debug.Log("attack");
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
}
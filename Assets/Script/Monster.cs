using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private MonsterData monsterData;
    public MonsterData MonsterData { set { monsterData = value; } }

    private Vector3 pos = Vector3.zero;
    
    public void WatchZombieInfo()
    {
        Debug.Log("좀비 이름 :: " + monsterData.MonsterName);
        Debug.Log("좀비 체력 :: " + monsterData.Hp);
        Debug.Log("좀비 공격력 :: " + monsterData.Damage);
        Debug.Log("좀비 시야 :: " + monsterData.SightRange);
        Debug.Log("좀비 이동속도 :: " + monsterData.MoveSpeed);
    }
    private void Update()
    {
        MoveToPlayer();
    }
    //플레이어한테 이동
    private void MoveToPlayer()
    {
        transform.position += (GameManager.instance.player.transform.position- transform.position) *monsterData.MoveSpeed*Time.deltaTime;
    }
}
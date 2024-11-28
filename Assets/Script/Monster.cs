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
        Debug.Log("���� �̸� :: " + monsterData.MonsterName);
        Debug.Log("���� ü�� :: " + monsterData.Hp);
        Debug.Log("���� ���ݷ� :: " + monsterData.Damage);
        Debug.Log("���� �þ� :: " + monsterData.SightRange);
        Debug.Log("���� �̵��ӵ� :: " + monsterData.MoveSpeed);
    }
    private void Update()
    {
        MoveToPlayer();
    }
    //�÷��̾����� �̵�
    private void MoveToPlayer()
    {
        transform.position += (GameManager.instance.player.transform.position- transform.position) *monsterData.MoveSpeed*Time.deltaTime;
    }
}
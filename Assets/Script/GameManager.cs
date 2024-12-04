using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] boxs = new GameObject[4];

    public GameObject[] monsters = null;

    public GameObject[] staticBoxs = null;

    [SerializeField]
    private Agent player = null;

    public int monsterNum = 4;
    private void Awake()
    {
        monsterNum = monsters.Length;   
    }
    public void ResetSetting()
    {
        //���� ���� ����
        monsterNum = 4;

        //box�� �ʱ�ȭ
        //y�� -16, 16 x�� -16���� 16
        for (int i = 0; i < boxs.Length; i++)
        {
            boxs[i].transform.localPosition = new Vector3(Random.Range(-16, 17), Random.Range(-16, 17), 0);
            boxs[i].SetActive(true);
        }

        //�н��� ���� �ʱ�ȭ
        for(int i=0; i< monsters.Length; i++)
        {
            Debug.Log(i);
            monsters[i].transform.localPosition = new Vector3(Random.Range(-16, 17), Random.Range(-16, 17), 0);
            monsters[i].GetComponent<Monster>().ResetSetting();
            monsters[i].SetActive(true);
        }

        for(int i =0; i < staticBoxs.Length; i++)
        {
            staticBoxs[i].SetActive(true);
        }
    }

    //�󽺰� �׾��� ��
    public void DeadMonster(GameObject monster)
    {
        monsterNum--;
        //�����߰�
        player.AddReward(0.5f);

        if(monsterNum == 0)
        {
            //��� ���͸� ���̸� ���� �߰�
            Debug.Log("���͸� ���� ���̼̽��ϴ�.");
            player.SetReward(1);
            player.EndEpisode();

            //�ٽ� ���� �ʱ�ȭ
            monsterNum = monsters.Length;
        }
        else
        {
            monster.SetActive(false);
        }
    }

    
}

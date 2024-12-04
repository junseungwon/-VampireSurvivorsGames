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
        //몬스터 숫자 리셋
        monsterNum = 4;

        //box값 초기화
        //y값 -16, 16 x도 -16에서 16
        for (int i = 0; i < boxs.Length; i++)
        {
            boxs[i].transform.localPosition = new Vector3(Random.Range(-16, 17), Random.Range(-16, 17), 0);
            boxs[i].SetActive(true);
        }

        //학습용 몬스터 초기화
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

    //몬스가 죽었을 때
    public void DeadMonster(GameObject monster)
    {
        monsterNum--;
        //보상추가
        player.AddReward(0.5f);

        if(monsterNum == 0)
        {
            //모든 몬스터를 죽이면 보상 추가
            Debug.Log("몬스터를 전부 죽이셨습니다.");
            player.SetReward(1);
            player.EndEpisode();

            //다시 정보 초기화
            monsterNum = monsters.Length;
        }
        else
        {
            monster.SetActive(false);
        }
    }

    
}

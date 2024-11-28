using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterType
{
    Normal, Power, Sensor, Speed, Tank
}

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<MonsterData> monsterDatas;

    [SerializeField]
    private GameObject monsterPrefab;

    void Start()
    {
        for (int i = 0; i < monsterDatas.Count; i++)
        {
            var monster = SpawnZombie((MonsterType)i);
            //monster.WatchZombieInfo();
        }
    }

    //���� �����ϰ� ���� �����̵��� ������
    public Monster SpawnZombie(MonsterType type)
    {
        var newZombie = Instantiate(monsterPrefab).GetComponent<Monster>();
        newZombie.MonsterData = monsterDatas[(int)type];
        return newZombie;
    }
}
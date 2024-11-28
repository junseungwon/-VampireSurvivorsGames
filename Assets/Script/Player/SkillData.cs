using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스킬 코드 ,스킬 이름, 스킬 계수(공격력, 힐, 방어력), 스킬 랭크, 스킬 이미지, 스킬 쿨타임
//공격 패턴 -> 배리어 공격, 미사일, 운석, 슬라이스 공격
[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data", order = int.MaxValue)]
public class SkillData : ScriptableObject
{


    [SerializeField]
    private int codeName;
    public int CodeName { get { return codeName; }  }

    [SerializeField]
    private string skillname;
    public string SkillName { get { return skillname; } }

    [SerializeField]
    private GameObject obj;
    public GameObject Obj { get { return obj; } }

    [SerializeField]
    private int rank;
    public int Rank { get { return rank; } }

    [SerializeField]
    private Sprite skillSprtie;
    public Sprite SkillSprite { get { return skillSprtie; } }


    [SerializeField]
    private SkillStruct[] rankDB;
    public SkillStruct[] RankDB { get { return rankDB; } }
    public int PlusRank()
    {
        rank++;
        return rank;
    }
    public void ResetData()
    {
        rank = 0;
    }
}
[System.Serializable]
public struct SkillStruct
{
    public float skillCoefficient;
    public float skillCoolTime;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ų �ڵ� ,��ų �̸�, ��ų ���(���ݷ�, ��, ����), ��ų ��ũ, ��ų �̹���, ��ų ��Ÿ��
//���� ���� -> �踮�� ����, �̻���, �, �����̽� ����
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

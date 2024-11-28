using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{
    [SerializeField]
    private int monsterCodeName;
    public int MonsterCodeName { get { return monsterCodeName; } }
    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } }
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }
    [SerializeField]
    private float sightRange;
    public float SightRange { get { return sightRange; } }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}

//��ų �ڵ� ,��ų �̸�, ��ų ���(���ݷ�, ��, ����), ��ų ��ũ, ��ų �̹���, ��ų ��Ÿ��
//���� ���� -> �踮�� ����, �̻���, �, �����̽� ����
[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
    [SerializeField]
    private int skillCodeName;
    public int SkillCodeName { get { return skillCodeName; } }

    [SerializeField]
    private string skillName;
    public string SkillName { get { return skillName; } }


    [SerializeField]
    private int skillRank;
    public int SkillRank { get { return skillRank; } }

    [SerializeField]
    private Sprite skillSprtie;
    public Sprite SkillSprite { get { return skillSprtie; } }

    //��ų ����� ��Ÿ�� ��ħ
    [SerializeField, Header("��ũ�� ��ų ����� ��Ÿ��")]
    private SkillStruct[] skillSp;
    public SkillStruct[] SkillSp { get { return skillSp; } }
   
    /*
    [SerializeField]
    private float skillCoefficient;
    public float Skillcoefficien { get { return skillCoefficient; } }
    
    [SerializeField]
    private int skillCoolTime;
    public int SkillCoolTime { get { return skillCoolTime; } }
    */
}
[System.Serializable]
public struct SkillStruct
{
    public float skillCoefficient;
    public float skillCoolTime;
}
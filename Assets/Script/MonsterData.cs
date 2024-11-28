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

//스킬 코드 ,스킬 이름, 스킬 계수(공격력, 힐, 방어력), 스킬 랭크, 스킬 이미지, 스킬 쿨타임
//공격 패턴 -> 배리어 공격, 미사일, 운석, 슬라이스 공격
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

    //스킬 계수랑 쿨타임 합침
    [SerializeField, Header("랭크별 스킬 계수랑 쿨타임")]
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
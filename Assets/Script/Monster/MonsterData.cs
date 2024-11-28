using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{

    //몬스터 코드 번호
    [SerializeField]
    private int monsterCodeName;
    public int MonsterCodeName { get { return monsterCodeName; } }

    //몬스터 이름
    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } }
   
    //몬스터 생명력
    [SerializeField]
    private int monsterHp;
    public int MonsterHp { get { return monsterHp; } }
    
    //몬스터 데미지
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    //움직임 속도
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}

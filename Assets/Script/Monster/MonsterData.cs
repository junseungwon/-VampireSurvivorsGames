using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterData : ScriptableObject
{

    //���� �ڵ� ��ȣ
    [SerializeField]
    private int monsterCodeName;
    public int MonsterCodeName { get { return monsterCodeName; } }

    //���� �̸�
    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } }
   
    //���� �����
    [SerializeField]
    private int monsterHp;
    public int MonsterHp { get { return monsterHp; } }
    
    //���� ������
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    //������ �ӵ�
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}

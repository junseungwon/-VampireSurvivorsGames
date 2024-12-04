using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillData[] skillDB = null;
    [SerializeField]
    private SkillBase[] skills = null;

    //��ų �߰�
    public void AddSkill(int num)
    {
        switch (num)
        {
            case (int)SkillType.Barrier:
                AddObject(SkillType.Barrier); break;

            case (int)SkillType.ShotGun:
                AddObject(SkillType.ShotGun); break;

            case (int)SkillType.Slice:
                AddObject(SkillType.Slice); break;

            //case (int)SkillType.HpUp:
              //  PlusHp(); break;

           // case (int)SkillType.SpeedUp:
             //   PlusSpeed(); break;
            default:
                Debug.LogError("�� �� ���� ��ų�� ������ �Ͽ����ϴ�."); break;
        }
    }

    //�߰��ϸ� �ش� db�� �ִ� gameobject�� player�� �߰��ع��� �״��� �ڷ�ƾ���� �ش� ��ų�� ������.
    //Ȱ��ȭ�� �Ǹ� �÷��̾����� �ڽ����� ������ ��. �״��� ��Ÿ�� ���� �۵��� �˾Ƽ� ��
    //���� ���� -> �踮�� ����, �̻���, �����̽� ����
    //�нú� ��ų
    public void AddObject(SkillType type)
    {
        //��ų�� 0���� �ƴ϶�� ��ũ�� �߰��Ѵ�.
        if (skills[(int)type].Rank > 1)
        {
            //skillDB[(int)type].GetComponent<SkillInterface>().plus
            //skillDB[(int)type].PlusRank();

            skills[(int)type].PlusRankValue();
            skills[(int)type].PlusRank();
            Debug.Log(skills[(int)type].Rank + "��ũ�� �ø��̽��ϴ�.");
            return;
        }

        //��ų�� Ȱ��ȭ ���ش�.
        skills[(int)type].gameObject.SetActive(true);
        skills[(int)type].enabled = true;
        skills[(int)type].PlusRankValue();
        Debug.Log(skills[(int)type].Rank + "��ũ�� �ø��̽��ϴ�.");
        
        //skillDB[(int)type].PlusRank();
    }

    //�ǰ� ȸ���ǰ� �ִ� ������� �����ŭ �þ��.
    public void PlusHp()
    {
       // GameManager.instance.player.Hp = skillDB[(int)SkillType.HpUp].RankDB[skillDB[(int)SkillType.HpUp].Rank-1].skillCoefficient;
    }

    //��ũ �����ŭ �÷��� ���ǵ尡 ����Ѵ�.
    public void PlusSpeed()
    {
        //GameManager.instance.player.Speed = skillDB[(int)SkillType.SpeedUp].RankDB[skillDB[(int)SkillType.SpeedUp].Rank-1].skillCoefficient;
    }

    public void SkillsReset()
    {
        //���� ��ų���� �������ְ� ���� ������ ��ų���� ��� �ı��Ѵ�.
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].SkillReset();
            skills[i].enabled = false;
            skills[i].gameObject.SetActive(false);
        }
    }
}


public enum SkillType
{
    Barrier, ShotGun, Slice, HpUp, SpeedUp
}


public class SkillBase :MonoBehaviour
{
    public int rank = 0;
    public int Rank { get { return rank; } set { if (rank+1 >= 3) rank = 3; rank = value; } }

    //��ũ ���� �Ǿ��� �� ����
    public virtual void PlusRank() { }

    public void PlusRankValue()
    {
        if (rank + 1 > 3)
        {
            rank = 3;
        }
        else
        {
            rank += 1;
        }
    }

    public void ResetRank() { rank = 0; }

    public virtual void SkillReset() { }
}


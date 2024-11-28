using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillData[] skillDB = null;

    private GameObject[] skills = null;
    private void Start()
    {
        skills = new GameObject[5];
    }
    //��ų �߰�
    public void AddSkill(SkillType type)
    {
        switch (type)
        {
            case SkillType.Barrier:
                AddObject(SkillType.Barrier); break;

            case SkillType.ShotGun:
                AddObject(SkillType.ShotGun); break;

            case SkillType.Slice:
                AddObject(SkillType.Slice); break;

            case SkillType.HpUp:
                PlusHp(); break;

            case SkillType.SpeedUp:
                PlusSpeed(); break;
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
        if(skillDB[(int)type].Rank != 0)
        {
            //skillDB[(int)type].PlusRank();
            skillDB[(int)type].GetComponent<SkillInterface>().PlusRank();
            return;
        }

        //0���̸� skill�� �����ϰ� ��ũ ++;
        skills[(int)type] = Instantiate(skillDB[(int)type].Obj);
        skills[(int)type].transform.parent = transform;
        skills[(int)type].transform.position = Vector3.zero;
        //skillDB[(int)type].PlusRank();
    }

    //�ǰ� ȸ���ǰ� �ִ� ������� �����ŭ �þ��.
    public void PlusHp()
    {
        GameManager.instance.player.Hp = skillDB[(int)SkillType.HpUp].RankDB[skillDB[(int)SkillType.HpUp].Rank].skillCoefficient;
    }

    //��ũ �����ŭ �÷��� ���ǵ尡 ����Ѵ�.
    public void PlusSpeed()
    {
        GameManager.instance.player.Speed = skillDB[(int)SkillType.SpeedUp].RankDB[skillDB[(int)SkillType.SpeedUp].Rank].skillCoefficient;
    }
    public enum SkillType
    {
        Barrier, ShotGun, Slice, HpUp, SpeedUp
    }
}
public interface SkillInterface
{
    //��ũ ���� �Ǿ��� �� ����
    public void PlusRank();
}

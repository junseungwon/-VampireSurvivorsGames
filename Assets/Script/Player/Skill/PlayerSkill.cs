using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private SkillData[] skillDB = null;
    [SerializeField]
    private SkillBase[] skills = null;

    //스킬 추가
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
                Debug.LogError("알 수 없는 스킬이 레벨업 하였습니다."); break;
        }
    }

    //추가하면 해당 db에 있는 gameobject를 player에 추가해버림 그다음 코루틴으로 해당 스킬을 실행함.
    //활성화가 되면 플레이어한테 자식으로 장착이 됨. 그다음 쿨타임 마다 작동이 알아서 됨
    //공격 패턴 -> 배리어 공격, 미사일, 슬라이스 공격
    //패시브 스킬
    public void AddObject(SkillType type)
    {
        //스킬이 0렙이 아니라면 랭크만 추가한다.
        if (skills[(int)type].Rank > 1)
        {
            //skillDB[(int)type].GetComponent<SkillInterface>().plus
            //skillDB[(int)type].PlusRank();

            skills[(int)type].PlusRankValue();
            skills[(int)type].PlusRank();
            Debug.Log(skills[(int)type].Rank + "랭크를 올리셨습니다.");
            return;
        }

        //스킬을 활성화 해준다.
        skills[(int)type].gameObject.SetActive(true);
        skills[(int)type].enabled = true;
        skills[(int)type].PlusRankValue();
        Debug.Log(skills[(int)type].Rank + "랭크를 올리셨습니다.");
        
        //skillDB[(int)type].PlusRank();
    }

    //피가 회복되고 최대 생명력이 계수만큼 늘어난다.
    public void PlusHp()
    {
       // GameManager.instance.player.Hp = skillDB[(int)SkillType.HpUp].RankDB[skillDB[(int)SkillType.HpUp].Rank-1].skillCoefficient;
    }

    //랭크 계수만큼 플레이 스피드가 상승한다.
    public void PlusSpeed()
    {
        //GameManager.instance.player.Speed = skillDB[(int)SkillType.SpeedUp].RankDB[skillDB[(int)SkillType.SpeedUp].Rank-1].skillCoefficient;
    }

    public void SkillsReset()
    {
        //각자 스킬들을 리셋해주고 각자 생성된 스킬들을 모두 파괴한다.
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

    //랭크 업이 되었으 때 설정
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


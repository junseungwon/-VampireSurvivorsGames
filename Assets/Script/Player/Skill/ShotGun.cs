using System.Collections;
using UnityEngine;

public class ShotGun : SkillBase
{
    [SerializeField]
    private SkillData skillDB = null;

    [SerializeField]
    private GameObject[] bullet = null;

    //쿨타임 가능 여부
    private bool isCool = false;

    //연속 샷
    private int continueFire = 0;

    private IEnumerator corutineCoolTimer = null;

    //랭크가 늘었났으면 연속샷 개수 추가
    public override void PlusRank()
    {
        Debug.Log("플러스");
        continueFire = rank;
    }

    //활성화 후에 총알들을 모두 que에 저장
    private void OnEnable()
    {

    }

    //비활성화
    private void OnDisable()
    {
        Debug.Log("비활성화");
        BulletSetting();
        SkillReset();
        //초기 연속 샷 설정
        continueFire = rank;
    }


    //충돌을 안하게 layer로 처리
    //몬스터는 데미지를 입는다.
    //총알을 자식으로 충돌처리는 여기서

    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectMonster(collision);
    }

    //쿨타임 발생
    private void StartCoolTimer()
    {
        if(this.gameObject.activeSelf == false)
        {
            return;
        }
        if (corutineCoolTimer != null)
        {
            StopCoroutine(corutineCoolTimer);
        }
        corutineCoolTimer = CoolTimer();
        StartCoroutine(corutineCoolTimer);
    }

    //쿨타임 코루틴
    private IEnumerator CoolTimer()
    {
        isCool = false;

        //랭크별 쿨타임을 받아와서 해당 시간만큼 쿨타임을 돌린다.
        Debug.Log(rank-1);
        yield return new WaitForSeconds(skillDB.RankDB[rank - 1].skillCoolTime);

        isCool = true;

        //랭크만큼 연속 샷이 가능하다.
        continueFire = rank;
    }

    //몬스터를 감지 했을 경우 총알을 발사한다.
    private void DetectMonster(Collider2D collision)
    {
        //쿨타임이 돌거나 연속샷일 경우 총알을 발사함
        if ((isCool || continueFire > 0) && collision.gameObject.layer == 3)
        {
            Debug.Log("Shot");

            //쿨타임이 true일 경우에만 true
            if (isCool&&this.gameObject.activeSelf == true) StartCoolTimer();

            //사격횟수 감소
            continueFire--;

            //총알이부족하면 생성해서 사용한다.
            if (transform.childCount == 0)
            {
                Instantiate(bullet[0], transform);
            }

            //랭크만큼 총알을 생성하고 몬스터에게 발사한다.
            for (int i = 0; i < rank; i++)
            {
                //총알 활성화 한 후에 몬스터를 대상으로 총알을 날리고 부모를 초기화
                transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log(rank+" "+transform.parent.parent.parent.name);
                transform.GetChild(0).gameObject.GetComponent<Bullet>().damage = skillDB.RankDB[rank].skillCoefficient;
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(10f * (collision.transform.position - transform.position));
                transform.GetChild(0).transform.parent = null;
            }
        }
    }


    //스킬을 리셋한다.
    public override void SkillReset()
    {
        if (corutineCoolTimer != null)
        {
            StopCoroutine(corutineCoolTimer);
        }
        rank = 0;
        BulletSetting();
        isCool = true;
        continueFire = rank;
    }

    //총알들을 재장전
    private void BulletSetting()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i].transform.parent = transform;
            bullet[i].gameObject.SetActive(false);
        }
    }
}

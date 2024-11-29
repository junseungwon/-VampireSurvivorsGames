using System.Collections;
using UnityEngine;

public class Barrier : MonoBehaviour, SkillInterface
{
    private IEnumerator corutine = null;
    [SerializeField]
    private SkillData skillDB = null;
    //랭크가 늘었났으면 베리어도 늘어나고 위치도 리셋
    public void PlusRank()
    {
        Debug.Log("플러스");

        //베리어 추가로 활성화
        transform.GetChild(skillDB.Rank-1).gameObject.SetActive(true);
    }

    //활성화
    private void OnEnable()
    {
        corutine = CorutinePlay();
        StartCoroutine(corutine);
    }

    //비활성화
    private void OnDisable()
    {
        StopCoroutine(corutine);
        Debug.Log("비활성화");
        skillDB.ResetData();
    }

    private IEnumerator CorutinePlay()
    {
        //첫 번째 베리어 활성화
        transform.GetChild(0).gameObject.SetActive(true);
        while (true)
        {
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌을 안하게 layer로 처리
        //몬스터는 데미지를 입는다.
       // Debug.Log("몬스터는 데미지를 입었습니다.");

    }

    public void SkillReset()
    {
        //자식 베리어들을 모두 비활성화
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        skillDB.ResetData();
    }
}

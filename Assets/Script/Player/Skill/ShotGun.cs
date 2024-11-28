using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour, SkillInterface
{
    public GameObject[] bullet = null;

    private void Awake()
    {
        
    }
    private IEnumerator corutine = null;

    [SerializeField]
    private SkillData skillDB = null;

    //랭크가 늘었났으면 베리어도 늘어나고 위치도 리셋
    public void PlusRank()
    {
        Debug.Log("플러스");

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
        while (true)
        {
            Play();
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void Play()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌을 안하게 layer로 처리
        //몬스터는 데미지를 입는다.
        //총알을 자식으로 충돌처리는 여기서
        Debug.Log("몬스터는 데미지를 입었습니다.");

    }
}

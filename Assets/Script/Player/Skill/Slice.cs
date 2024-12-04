using System.Collections;
using Unity.MLAgents;
using UnityEngine;

public class Slice : SkillBase
{
    [SerializeField]
    private GameObject[] sliceObject = null;

    [SerializeField]
    private SkillData skillDB = null;

    private IEnumerator corutine = null;
    //Ȱ��ȭ
    private void OnEnable()
    {
        corutine = CorutinePlay();
        Debug.Log("slice");
        StartCoroutine(corutine);
    }

    //��Ȱ��ȭ
    private void OnDisable()
    {
        StopCoroutine(corutine);
        Debug.Log("��Ȱ��ȭ");
        rank = 0;
        
    }

    private IEnumerator CorutinePlay()
    {
        while (true)
        {
            sliceObject[0].SetActive(true);
            sliceObject[1].SetActive(false);
            yield return new WaitForSeconds(0.2f);

            //��ų ��ũ�� 1 �þ�� �����̽� ���ݵ� �þ
            if (rank > 1)
            {
                sliceObject[0].SetActive(false);
                sliceObject[1].SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }

            sliceObject[0].SetActive(false);
            sliceObject[1].SetActive(false);

            //��Ÿ��
            yield return new WaitForSeconds(skillDB.RankDB[rank - 1].skillCoolTime);
        }
    }

    //������ ���Ϳ��� ������ ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerName.Monster)
        {
            collision.gameObject.transform.parent.GetComponent<Monster>().HitDamage(skillDB.RankDB[rank - 1].skillCoefficient);
        }
    }

    public override void SkillReset()
    {
        if (corutine != null)
        {
            StopCoroutine(corutine);
        }

        sliceObject[0].SetActive(false);
        sliceObject[1].SetActive(false);

        //��ũ �ʱ�ȭ
        rank = 0;
    }

    //��ũ�� �þ������� ����� �þ�� ��ġ�� ����
    public override void PlusRank()
    {
        Debug.Log("�÷���");
    }
}

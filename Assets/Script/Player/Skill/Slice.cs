using System.Collections;
using UnityEngine;

public class Slice : MonoBehaviour, SkillInterface
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
        StartCoroutine(corutine);
    }

    //��Ȱ��ȭ
    private void OnDisable()
    {
        StopCoroutine(corutine);
        Debug.Log("��Ȱ��ȭ");
        skillDB.ResetData();
    }

    private IEnumerator CorutinePlay()
    {
        while (true)
        {
            sliceObject[0].SetActive(true);
            sliceObject[1].SetActive(false);
            yield return new WaitForSeconds(0.2f);

            //��ų ��ũ�� 1 �þ�� �����̽� ���ݵ� �þ
            if (skillDB.Rank > 1)
            {
                sliceObject[0].SetActive(false);
                sliceObject[1].SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }

            sliceObject[0].SetActive(false);
            sliceObject[1].SetActive(false);

            //��Ÿ��
            Debug.Log(skillDB.Rank);
            yield return new WaitForSeconds(skillDB.RankDB[skillDB.Rank-1].skillCoolTime);
        }
    }

    //������ ���Ϳ��� ������ ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)LayerName.Monster)
        {
            Debug.Log("����");
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void SkillReset()
    {
        StopCoroutine(corutine);

        sliceObject[0].SetActive(false);
        sliceObject[1].SetActive(false);

        //��ũ �ʱ�ȭ
        skillDB.ResetData();
    }

    //��ũ�� �þ������� ����� �þ�� ��ġ�� ����
    public void PlusRank()
    {
        Debug.Log("�÷���");

    }
}

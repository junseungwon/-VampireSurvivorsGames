using System.Collections;
using UnityEngine;

public class Barrier : SkillBase
{
    private IEnumerator corutine = null;
    [SerializeField]
    private SkillData skillDB = null;


    //��ũ�� �þ������� ����� �þ�� ��ġ�� ����
    public override void PlusRank()
    {
        Debug.Log("�÷���");

        //������ �߰��� Ȱ��ȭ
        transform.GetChild(rank-1).gameObject.SetActive(true);
    }

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
        rank = 0;
    }

    private IEnumerator CorutinePlay()
    {
        //ù ��° ������ Ȱ��ȭ
        transform.GetChild(0).gameObject.SetActive(true);
        while (true)
        {
            transform.Rotate(0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹�� ���ϰ� layer�� ó��
        //���ʹ� �������� �Դ´�.
        // Debug.Log("���ʹ� �������� �Ծ����ϴ�.");
        if (collision.gameObject.layer == (int)LayerName.Monster)
        {
            Debug.Log("����"+ rank+" "+transform.parent.parent.parent.name);
            if (rank == 0) return;
            collision.gameObject.transform.parent.GetComponent<Monster>().HitDamage(skillDB.RankDB[rank - 1].skillCoefficient);

            //collision.gameObject.transform.parent.gameObject.SetActive(false);
        }

    }

    public override void SkillReset()
    {
        if(corutine != null)
        {
            StopCoroutine(corutine);
        }
        //�ڽ� ��������� ��� ��Ȱ��ȭ
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        rank = 0;
    }
}

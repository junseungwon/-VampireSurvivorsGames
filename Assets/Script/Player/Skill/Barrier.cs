using System.Collections;
using UnityEngine;

public class Barrier : MonoBehaviour, SkillInterface
{
    private IEnumerator corutine = null;
    [SerializeField]
    private SkillData skillDB = null;
    //��ũ�� �þ������� ����� �þ�� ��ġ�� ����
    public void PlusRank()
    {
        Debug.Log("�÷���");

        //������ �߰��� Ȱ��ȭ
        transform.GetChild(skillDB.Rank-1).gameObject.SetActive(true);
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
        skillDB.ResetData();
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

    }

    public void SkillReset()
    {
        //�ڽ� ��������� ��� ��Ȱ��ȭ
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        skillDB.ResetData();
    }
}

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

    //��ũ�� �þ������� ����� �þ�� ��ġ�� ����
    public void PlusRank()
    {
        Debug.Log("�÷���");

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
        //�浹�� ���ϰ� layer�� ó��
        //���ʹ� �������� �Դ´�.
        //�Ѿ��� �ڽ����� �浹ó���� ���⼭
        Debug.Log("���ʹ� �������� �Ծ����ϴ�.");

    }
}

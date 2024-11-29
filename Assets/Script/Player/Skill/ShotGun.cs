using System.Collections;
using UnityEngine;

public class ShotGun : MonoBehaviour, SkillInterface
{
    [SerializeField]
    private SkillData skillDB = null;

    [SerializeField]
    private GameObject[] bullet = null;

    //��Ÿ�� ���� ����
    private bool isCool = false;

    //���� ��
    private int continueFire = 0;

    private IEnumerator corutineCoolTimer = null;

    //��ũ�� �þ������� ���Ӽ� ���� �߰�
    public void PlusRank()
    {
        Debug.Log("�÷���");
        continueFire = skillDB.Rank;
    }

    //Ȱ��ȭ �Ŀ� �Ѿ˵��� ��� que�� ����
    private void OnEnable()
    {
        SkillReset();
    }

    //��Ȱ��ȭ
    private void OnDisable()
    {
        Debug.Log("��Ȱ��ȭ");
        BulletSetting();
        SkillReset();
        //�ʱ� ���� �� ����
        continueFire = skillDB.Rank;
    }


    //�浹�� ���ϰ� layer�� ó��
    //���ʹ� �������� �Դ´�.
    //�Ѿ��� �ڽ����� �浹ó���� ���⼭

    private void OnTriggerStay2D(Collider2D collision)
    {
        DetectMonster(collision);
    }

    //��Ÿ�� �߻�
    private void StartCoolTimer()
    {
        corutineCoolTimer = CoolTimer();
        StartCoroutine(corutineCoolTimer);  
    }

    //��Ÿ�� �ڷ�ƾ
    private IEnumerator CoolTimer()
    {
        isCool = false;

        //��ũ�� ��Ÿ���� �޾ƿͼ� �ش� �ð���ŭ ��Ÿ���� ������.
        yield return new WaitForSeconds(skillDB.RankDB[skillDB.Rank-1].skillCoolTime);
       
        isCool = true;

        //��ũ��ŭ ���� ���� �����ϴ�.
        continueFire = skillDB.Rank;
    }

    //���͸� ���� ���� ��� �Ѿ��� �߻��Ѵ�.
    private void DetectMonster(Collider2D collision)
    {
        //��Ÿ���� ���ų� ���Ӽ��� ��� �Ѿ��� �߻���
        if ((isCool || continueFire >0 )&& collision.gameObject.layer == 3)
        {
            Debug.Log("Shot");

            //��Ÿ���� true�� ��쿡�� true
            if (isCool)StartCoolTimer();

            //���Ƚ�� ����
            continueFire--;
            
            //�Ѿ��̺����ϸ� �����ؼ� ����Ѵ�.
            if (transform.childCount == 0)
            {
                Instantiate(bullet[0], transform);
            }

            //��ũ��ŭ �Ѿ��� �����ϰ� ���Ϳ��� �߻��Ѵ�.
            for (int i = 0; i < skillDB.Rank; i++)
            {
                //�Ѿ� Ȱ��ȭ �� �Ŀ� ���͸� ������� �Ѿ��� ������ �θ� �ʱ�ȭ
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(10f * (collision.transform.position - transform.position));
                transform.GetChild(0).transform.parent = null;
            }
        }
    }


    //��ų�� �����Ѵ�.
    public void SkillReset()
    {
        skillDB.ResetData();
        BulletSetting();
        isCool = true;
        continueFire = skillDB.Rank;
    }

    //�Ѿ˵��� ������
    private void BulletSetting()
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i].transform.parent = transform;
            bullet[i].gameObject.SetActive(false);
        }
    }
}

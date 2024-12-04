using System.Collections;
using UnityEngine;

public class ShotGun : SkillBase
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
    public override void PlusRank()
    {
        Debug.Log("�÷���");
        continueFire = rank;
    }

    //Ȱ��ȭ �Ŀ� �Ѿ˵��� ��� que�� ����
    private void OnEnable()
    {

    }

    //��Ȱ��ȭ
    private void OnDisable()
    {
        Debug.Log("��Ȱ��ȭ");
        BulletSetting();
        SkillReset();
        //�ʱ� ���� �� ����
        continueFire = rank;
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

    //��Ÿ�� �ڷ�ƾ
    private IEnumerator CoolTimer()
    {
        isCool = false;

        //��ũ�� ��Ÿ���� �޾ƿͼ� �ش� �ð���ŭ ��Ÿ���� ������.
        Debug.Log(rank-1);
        yield return new WaitForSeconds(skillDB.RankDB[rank - 1].skillCoolTime);

        isCool = true;

        //��ũ��ŭ ���� ���� �����ϴ�.
        continueFire = rank;
    }

    //���͸� ���� ���� ��� �Ѿ��� �߻��Ѵ�.
    private void DetectMonster(Collider2D collision)
    {
        //��Ÿ���� ���ų� ���Ӽ��� ��� �Ѿ��� �߻���
        if ((isCool || continueFire > 0) && collision.gameObject.layer == 3)
        {
            Debug.Log("Shot");

            //��Ÿ���� true�� ��쿡�� true
            if (isCool&&this.gameObject.activeSelf == true) StartCoolTimer();

            //���Ƚ�� ����
            continueFire--;

            //�Ѿ��̺����ϸ� �����ؼ� ����Ѵ�.
            if (transform.childCount == 0)
            {
                Instantiate(bullet[0], transform);
            }

            //��ũ��ŭ �Ѿ��� �����ϰ� ���Ϳ��� �߻��Ѵ�.
            for (int i = 0; i < rank; i++)
            {
                //�Ѿ� Ȱ��ȭ �� �Ŀ� ���͸� ������� �Ѿ��� ������ �θ� �ʱ�ȭ
                transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log(rank+" "+transform.parent.parent.parent.name);
                transform.GetChild(0).gameObject.GetComponent<Bullet>().damage = skillDB.RankDB[rank].skillCoefficient;
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(10f * (collision.transform.position - transform.position));
                transform.GetChild(0).transform.parent = null;
            }
        }
    }


    //��ų�� �����Ѵ�.
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

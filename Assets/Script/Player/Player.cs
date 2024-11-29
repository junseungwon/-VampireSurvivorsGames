using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    //�÷��̾� ���ǵ�
    [SerializeField]
    private float speed = 5f;
    public float Speed { set { speed = value; } get { return speed; } }

    //�÷��̾� ���
    private float hp = 3;
    public float Hp { set { hp = value; if (hp == 0) PlayerDead(); } get { return hp; } }

    //���� �¿� ������ ����
    private float LeftRight = 0F;
    private float upDown = 0F;

    //�÷��̾� vector��
    private Vector3 pos = Vector3.zero;


    [SerializeField]
    private PlayerSkill skill = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
        
        //�⺻ ����
        skill.AddSkill((int)SkillType.Slice);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //�÷��̾� �浹 �ڵ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ ���� ��
        if (collision.gameObject.layer == (int)LayerName.ItemBox)
        {
            //�ڽ� ��Ȱ��ȭ �Ŀ� �ڽ� ����
            collision.gameObject.SetActive(false);
            OpenItemBox();
        }
    }

    //�÷��̾� ������ ����

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        upDown = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        pos.x += LeftRight;
        pos.y += upDown;
        player.transform.position = pos;
    }

    private void PlayerDead()
    {
        ResetInform();
    }
    //������ ������ ������
    //���� �������� ȹ����
    private void OpenItemBox()
    {
        int randomNum = Random.Range(0, 3);
        Debug.Log($"�ڽ��� ȹ���ϼ̽��ϴ�. {randomNum}");
        skill.AddSkill(randomNum);
    }

    //ü���̶� �ӵ��� reset �׸��� �÷��̾� ��ġ �ʱ�ȭ pos�� �ʱ�ȭ ��ų�� �ʱ�ȭ
    private void ResetInform()
    {
        hp = 3;
        speed = 5f;
        player.transform.position = Vector3.zero;
        pos = Vector3.zero;
        skill.SkillsReset();
    }
}
public enum LayerName
{
    Monster = 3, Attack = 6, Player = 7, ItemBox = 8
    //3 6 7 8
}


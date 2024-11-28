using UnityEngine;

public class Player : MonoBehaviour
{
    //�÷��̾� ���ǵ�
    [SerializeField]
    private float speed = 5f;
    
    //�÷��̾� ���
    private int hp = 3;
    public int Hp { set { hp = value; } get { return hp; } }

    //���� �¿� ������ ����
    private float LeftRight = 0F;
    private float upDown = 0F;
    
    //�÷��̾� vector��
    private  Vector3 pos = Vector3.zero;


    [SerializeField]
    private SkillData[] skillDB;
    public SkillData[] SkillDB { set { skillDB = value; } }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //�÷��̾� �浹 �ڵ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tri"+collision.gameObject.name);
    }

    //�÷��̾� ������ ����

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        upDown = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        pos.x += LeftRight;
        pos.y += upDown;
        transform.position = pos;
    }


    //���� ���� -> �踮�� ����, �̻���, �, �����̽� ����

}

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
    public float Hp { set { hp = value; } get { return hp; } }

    //���� �¿� ������ ����
    private float LeftRight = 0F;
    private float upDown = 0F;
    
    //�÷��̾� vector��
    private  Vector3 pos = Vector3.zero;


    [SerializeField]
    private PlayerSkill skill = null;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this;
        skill.AddSkill(PlayerSkill.SkillType.Barrier);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //�÷��̾� �浹 �ڵ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("tri"+collision.gameObject.name);
    }

    //�÷��̾� ������ ����

    private void PlayerMove()
    {
        LeftRight = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        upDown = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        pos.x += LeftRight;
        pos.y += upDown;
        player.transform.position = pos;
    }


}

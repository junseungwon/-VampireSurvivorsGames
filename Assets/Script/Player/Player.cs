using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class Player : Agent
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

    [SerializeField]
    private GameManager gameManager = null;

    private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

            //�ڽ��� ������ �����߰�
            AddReward(1);
        }
    }

    //�÷��̾� ������ ����

    private void PlayerDead()
    {
        //������ ���� -1
        AddReward(-1);
        Debug.Log("���� �����");
        EndEpisode();
    }
    //������ ������ ������
    //���� �������� ȹ����
    private void OpenItemBox()
    {
        int randomNum = Random.Range(0, 3);
        skill.AddSkill(randomNum);
    }

    //ü���̶� �ӵ��� reset �׸��� �÷��̾� ��ġ �ʱ�ȭ pos�� �ʱ�ȭ ��ų�� �ʱ�ȭ
    private void ResetInform()
    {
        hp = 3;
        speed = 5f;
        player.transform.localPosition = Vector3.zero;
        pos = Vector3.zero;

        //��ų�� ����
        skill.SkillsReset();

        //���Ͷ� �ڽ��� ����
        gameManager.ResetSetting();
    }

    //���Ǽҵ� ����
    public override void OnEpisodeBegin()
    {
        //������ �ʱ�ȭ
        ResetInform();
        //�⺻ ����
        skill.AddSkill((int)SkillType.Slice);
    }

    //�Է¹��� ���
    public override void OnActionReceived(ActionBuffers actions)
    {
        upDown = actions.ContinuousActions[1];
        LeftRight = actions.ContinuousActions[0];
    }

    //������
    private void PlayerMove()
    {
        pos.x += LeftRight * Time.deltaTime * speed;
        pos.y += upDown * Time.deltaTime * speed;

        if (pos.x > 20) pos.x = 20;
        if (pos.x < -20) pos.x = -20;
        if (pos.y > 20) pos.y = 20;
        if (pos.y < -20) pos.y = -20;
        player.transform.localPosition = pos;
    }

    //���� �Է�
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continueAction = actionsOut.ContinuousActions;
        continueAction[0] = Input.GetAxis("Horizontal");
        continueAction[1] = Input.GetAxis("Vertical");
        upDown = continueAction[1];
        LeftRight = continueAction[0];
    }
}
public enum LayerName
{
    Monster = 3, Attack = 6, Player = 7, ItemBox = 8
    //3 6 7 8
}


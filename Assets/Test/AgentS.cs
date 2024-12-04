using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class AgentS : Agent
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public Transform target = null;

    public override void OnEpisodeBegin()
    {
        if (transform.localPosition.y < 0)
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
    }

        
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.localPosition);
        sensor.AddObservation(transform.localPosition);

        //sensor.AddObservation(rb.velocity.x);
       // sensor.AddObservation(rb.velocity.z);
    }
    

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];

        rb.AddForce(controlSignal * 50);

        float distance =  Vector3.Distance(transform.localPosition, target.localPosition);

        AddReward(-0.01f);
        if (distance < 1.4f)
        {
           // SetReward(1.0f);
            //EndEpisode();
        }
        if (transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "box")
        {
            SetReward(1.0f);
            EndEpisode();
            Debug.Log("Ãæµ¹");
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
        var continueAction = actionsOut.ContinuousActions;
        continueAction[0] = Input.GetAxis("Horizontal");
        continueAction[1] = Input.GetAxis("Vertical");
        
    }
}

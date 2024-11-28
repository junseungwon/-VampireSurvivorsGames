using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    private Vector3 v3 = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        v3+= (GameManager.instance.player.transform.position - transform.position) * moveSpeed * Time.deltaTime; ;
        v3.z = -10f;
        transform.position = v3;
    }
}
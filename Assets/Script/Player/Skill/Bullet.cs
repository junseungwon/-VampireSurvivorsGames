using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 0f;
    private Transform parento = null;
    private void Awake()
    {
        parento = transform.parent;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("몬스터 적중");
            transform.parent = parento;
            transform.localPosition = Vector3.zero;
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

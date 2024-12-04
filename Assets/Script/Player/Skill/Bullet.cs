using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 0f;
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
            collision.gameObject.GetComponent<Monster>().HitDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
}

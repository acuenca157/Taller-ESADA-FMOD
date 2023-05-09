using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Color[] colores;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int damage = 5;
    [SerializeField] private float life = 1f;

    private SpriteRenderer sprite;
    void Awake()
    {
        Destroy(this.gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyController>().recibirDamage(damage);
            Destroy(this.gameObject);
        }
        if (collision.transform.tag != "Player") {
            Destroy(this.gameObject);
        }

    }
}

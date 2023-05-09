using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Color[] colores;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int damage = 5;
    [SerializeField] private EventReference damageEvent;
    [SerializeField] private float life = 1f;

    private SpriteRenderer sprite;
    void Awake()
    {
        Destroy(this.gameObject, life);
    }

    private void Start()
    {
        //int colorId = Random.Range(0, colores.Length);
        //int spriteId = Random.Range(0, sprites.Length);
        //sprite = GetComponentInChildren<SpriteRenderer>();
        //sprite.color = colores[colorId];
        //sprite.sprite = sprites[spriteId];
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

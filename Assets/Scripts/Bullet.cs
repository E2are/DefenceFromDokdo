using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public float damage;
    public Vector3 dir;
    public float speed;
    public bool is_enemy_bullet;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border") Destroy(this.gameObject);

        if (!is_enemy_bullet)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
                other.gameObject.GetComponent<Enemy>().hp -= damage;
                if (other.gameObject.GetComponent<Enemy>().hp <= 0)
                {
                    GameManager.instance.bs.fishCoin += other.gameObject.GetComponent<Enemy>().type * 20;
                    GameManager.instance.bs.kill_cnt++;
                    Destroy(other.gameObject);
                }
            }
            if (other.gameObject.tag == "Boss")
            {
                other.gameObject.GetComponent<BossEnemy>().hp -= damage;
                if (other.gameObject.GetComponent<BossEnemy>().hp <= 0)
                {
                    other.gameObject.GetComponent<SpriteRenderer>().flipY = true;
                    other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
                other.gameObject.GetComponent<Guard>().hp -= damage;
                if (other.gameObject.GetComponent<Guard>().hp <= 0)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public float hp;
    public GameObject bullet_prefeb;
    public int type;
    public float speed = 0.5f;
    bool shoot = true;
    float len;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Translate(speed * -1, 0f, 0f);
        switch (type)
        {
            case 1:
                Shoot_troop(GGuang(), 2f);
                break;
            case 2:
                Shoot_troop(Cat(), 2f);
                break;
            case 3:
                Shoot_troop(gorilla(), 2f);
                break;
        }

    }

    void Shoot_troop(IEnumerator enu, float leng)
    {
        if (shoot)
        {
            StartCoroutine(enu);
            shoot = !shoot;
            len = leng;
        }
    }


    IEnumerator GGuang()
    {
        while (true)
        {
            RaycastHit2D ray = Physics2D.Raycast(rigid.position, Vector3.right * -1, len, LayerMask.GetMask("Turret"));
            if (ray.collider != null)
            {
                bullet_prefeb.GetComponent<Bullet>().dir = Vector3.right * -1;
                bullet_prefeb.GetComponent<Bullet>().damage = 3;
                bullet_prefeb.GetComponent<Bullet>().speed = 5f;
                bullet_prefeb.GetComponent<Bullet>().is_enemy_bullet = true;
                Instantiate(bullet_prefeb, this.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    IEnumerator Cat()
    {
        while (true)
        {
            RaycastHit2D ray = Physics2D.Raycast(rigid.position, Vector3.right * -1, len, LayerMask.GetMask("Turret"));
            if (ray.collider != null)
            {
                anim.SetBool("Attack", true);
                bullet_prefeb.GetComponent<Bullet>().dir = Vector3.right * -1;
                bullet_prefeb.GetComponent<Bullet>().damage = 4;
                bullet_prefeb.GetComponent<Bullet>().speed = 5f;
                bullet_prefeb.GetComponent<Bullet>().is_enemy_bullet = true;
                Instantiate(bullet_prefeb, this.transform.position, Quaternion.identity);
            }
            else
            {
                anim.SetBool("Attack", false);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator gorilla()
    {
        while (true)
        {
            RaycastHit2D ray = Physics2D.Raycast(rigid.position, Vector3.right * -1, len, LayerMask.GetMask("Turret"));
            if (ray.collider != null)
            {
                anim.SetTrigger("Attack");
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, new Vector2(5, 3), 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Player")
                    {
                        collider.GetComponent<Guard>().hp -= 10;
                        if (collider.GetComponent<Guard>().hp <= 0)
                        {
                            Destroy(collider.gameObject);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

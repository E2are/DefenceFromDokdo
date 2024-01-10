using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Guard : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public float hp;
    public GameObject bullet_prefeb;
    public int type;
    bool shoot = true;
    float len;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(type){
            case 1:
            Shoot_troop(Gangchi(),6f);
            break;
            case 2:
            Shoot_troop(Btsea(),2f);
            break;
            case 3:
            Shoot_troop(Anchovy(),5f);
            break;
            case 4:
            Shoot_troop(blowfish(),2f);
            break;
        }
            
    }

    void Shoot_troop(IEnumerator enu, float leng){
        if(shoot){
        StartCoroutine(enu);
        shoot = !shoot;
        len = leng;
        }
    }


    IEnumerator Gangchi()
    {
        while(true){
            RaycastHit2D ray = Physics2D.Raycast(rigid.position,Vector3.right,len,LayerMask.GetMask("Enemy"));
            if(ray.collider != null){            
                bullet_prefeb.GetComponent<Bullet>().dir = Vector3.right;
                bullet_prefeb.GetComponent<Bullet>().damage = 5;
                bullet_prefeb.GetComponent<Bullet>().speed = 5f;
                bullet_prefeb.GetComponent<Bullet>().is_enemy_bullet = false;
                Instantiate(bullet_prefeb, this.transform.position, quaternion.identity);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
    IEnumerator Anchovy()
    {
        while(true){
            RaycastHit2D ray = Physics2D.Raycast(rigid.position,Vector3.right,len,LayerMask.GetMask("Enemy"));
            if(ray.collider != null){    
                bullet_prefeb.GetComponent<Bullet>().dir = Vector3.right;
                bullet_prefeb.GetComponent<Bullet>().damage = 2;
                bullet_prefeb.GetComponent<Bullet>().speed = 5f;
                bullet_prefeb.GetComponent<Bullet>().is_enemy_bullet = false;
                Instantiate(bullet_prefeb, this.transform.position, quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Btsea()
    {
        while(true){
            RaycastHit2D ray = Physics2D.Raycast(rigid.position,Vector3.right,len,LayerMask.GetMask("Enemy"));
            if(ray.collider != null){    
                anim.SetBool("Attack",true);
                bullet_prefeb.GetComponent<Bullet>().dir = Vector3.right;
                bullet_prefeb.GetComponent<Bullet>().damage = 4;
                bullet_prefeb.GetComponent<Bullet>().speed = 5f;
                bullet_prefeb.GetComponent<Bullet>().is_enemy_bullet = false;
                Instantiate(bullet_prefeb, this.transform.position, quaternion.identity);
            }
            else{
                anim.SetBool("Attack",false);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator blowfish()
    {
        while(true){
            RaycastHit2D ray = Physics2D.Raycast(rigid.position,Vector3.right,len,LayerMask.GetMask("Enemy"));
            if(ray.collider != null){    
                anim.SetTrigger("Attack");
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, new Vector2(3,3), 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Enemy>().hp -= 5;
                        if(collider.GetComponent<Enemy>().hp <=0){
                            Destroy(collider.gameObject);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

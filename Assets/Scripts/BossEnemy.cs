using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Transform[] f_pos;
    public GameObject b_bullet;
    public GameObject[] Minions;
    public float hp;
    bool spawned = false;

    void Start()
    {
        StartCoroutine(Phase_1());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 9 && GameManager.instance.bs.kill_cnt >= 30)
        {
            transform.Translate(-0.05f, 0f, 0f);
        }
    }
    IEnumerator Phase_1()
    {
        while (hp > 0)
        {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i <= 4; i++)
            {
                b_bullet.GetComponent<Bullet>().dir = UnityEngine.Vector3.right * -1;
                b_bullet.GetComponent<Bullet>().damage = 3;
                b_bullet.GetComponent<Bullet>().speed = 5f;
                b_bullet.GetComponent<Bullet>().is_enemy_bullet = true;
                Instantiate(b_bullet, f_pos[i].position, UnityEngine.Quaternion.identity);
            }
        }
    }
}

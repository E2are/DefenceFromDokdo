
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Spawner : MonoBehaviour
{
    public Transform[] Waves;
    public GameObject[] Minions;
    public GameObject Boss;
    float percent;
    int ene;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    void Update()
    {
        percent = UnityEngine.Random.Range(0, (float)(GameManager.instance.bs.kill_cnt));
        if (percent < 20f)
        {
            ene = 0;
        }
        else if (percent < 25f)
        {
            ene = 1;
        }
        else
        {
            ene = 2;
        }
        if (GameManager.instance.bs.kill_cnt >= 30)
        {
            Boss.SetActive(true);
        }
    }
    IEnumerator Spawn()
    {
        while (Boss.GetComponent<BossEnemy>().hp > 0)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 4f));
            Instantiate(Minions[ene], Waves[UnityEngine.Random.Range(0, 5)].position, UnityEngine.Quaternion.identity);
        }
    }
}

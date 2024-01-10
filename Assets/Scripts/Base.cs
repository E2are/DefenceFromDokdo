using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Base : MonoBehaviour
{
    public float fishCoin = 100;
    public float Base_hp;
    public float max_hp = 5f;
    public int kill_cnt = 0;
    public Slider slider;
    public Text coin;
    public GameObject[] Uis;
    public GameObject[] GameOver;
    public bool lose = false;

    void Update()
    {
        slider.value = Base_hp / max_hp;
        coin.text = fishCoin.ToString();
        if (lose)
        {
            for (int i = 0; i < GameOver.Length; i++)
            {
                GameOver[i].SetActive(true);
            }
            for (int i = 0; i < Uis.Length; i++)
            {
                Uis[i].SetActive(false);
            }

        }
        else
        {
            for (int i = 0; i < GameOver.Length; i++)
            {
                GameOver[i].SetActive(false);
            }
            for (int i = 0; i < Uis.Length; i++)
            {
                Uis[i].SetActive(true);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Base_hp -= 1;
            Destroy(other.gameObject);
            GameManager.instance.qz.QuizUp();
            if (Base_hp <= 0)
            {
                lose = true;
            }


        }
    }
}

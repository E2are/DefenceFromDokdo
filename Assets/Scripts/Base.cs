using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Base : MonoBehaviour
{
    public int hp;
    public float fishCoin = 100;
    public float Base_hp;
    public float max_hp=5f;
    public Slider slider;
    public Text coin;
    public bool lose=false;

    void Update()
    {
        slider.value = Base_hp/max_hp;
        coin.text = fishCoin.ToString(); 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Base_hp -= 1;
            if(Base_hp<=0){
                lose = true;
            }
        }
    }
}

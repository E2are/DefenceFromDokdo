using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>6){
            transform.Translate(0.05f,0f,0f);
            StartCoroutine(Phase_1());
        }
    }
    IEnumerator Phase_1(){
        while(true){
            yield return new WaitForSeconds(1.5f);
        }
    }
}

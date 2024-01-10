using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] turrets;
    
    Vector3 mousePosition;
    Camera Camera;
    public bool selected=false;
    public int type=0;

    void Start() {
        Camera = GetComponent<Camera>();
    }
    void Update()
    {
        Spawn();
    }
    void Spawn(){
        // Vector3 pos = Input.mousePosition
        if(Input.GetMouseButtonDown(0)){
            mousePosition = Input.mousePosition;
            mousePosition = Camera.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 10f);
            Debug.DrawRay(mousePosition,transform.forward * 10,Color.red, 0.3f);
            if(selected &&hit != null&& hit.collider.tag == "Tile"){
                selected = false;
                Instantiate(turrets[type], new Vector3(hit.transform.position.x, hit.transform.position.y,-3f), Quaternion.identity);
            }
        }
    }
}

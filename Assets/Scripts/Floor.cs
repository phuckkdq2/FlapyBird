using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float moveSpeed;
    GameController m_gc;
    
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gc.IsGameOver()) return;

        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x <= -5.5f){
            transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        }
       
    }
}

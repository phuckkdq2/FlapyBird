using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    void Update()
    {
        if(GameController.Instance.IsGameOver()) return;

        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x <= -5.5f){
            transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        }
       
    }
}

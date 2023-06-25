using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1.8f;
    void Start()
    {

    }
    void Update()
    {
        if(GameController.Instance.IsGameOver()) return;

        transform.parent.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }
}

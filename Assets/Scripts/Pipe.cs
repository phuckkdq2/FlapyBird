using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
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

        Destroy(gameObject, 4f);
    }
}

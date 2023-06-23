using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rb;
    GameController m_gc;

    public AudioSource aus;
    public AudioClip flap;
    public AudioClip hit;
    public AudioClip die ;
    public AudioClip score;

    public float bouncingForce; // lực nảy 

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(m_gc.IsGameOver()){
            return;
        }

        if(Input.GetMouseButtonDown(0)){
            m_rb.AddForce(Vector2.up * bouncingForce );
            if(aus && flap){
                aus.PlayOneShot(flap);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(m_gc.IsGameOver()){
            return;
        }
        
        if(other.CompareTag("Pass")){
            m_gc.ScoreIncrement();
            if(aus&&score){
                aus.PlayOneShot(score);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("floor")){
            m_gc.SetGameOverState(true);
            if(aus&&hit && die){
                aus.PlayOneShot(hit);
                aus.PlayOneShot(die);
            } 
            
        }

        if(other.gameObject.CompareTag("Pipe")){
            
            m_gc.SetGameOverState(true);    
            if(aus&&hit&& die){
                aus.PlayOneShot(hit);
                aus.PlayOneShot(die);
            } 
            
        }

    }

}

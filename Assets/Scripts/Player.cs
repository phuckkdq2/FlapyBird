using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Darwin
{
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] public AudioSource aus;
    [SerializeField] public AudioClip flap;
    [SerializeField] public AudioClip hit;
    [SerializeField] public AudioClip die ;
    [SerializeField] public AudioClip score;

    [SerializeField] public float bouncingForce; // lực nảy 

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }
    
    protected virtual void LoadRigidbody()
    {
        if(m_rb != null) return;
        this.m_rb = transform.GetComponent<Rigidbody2D>();
    }  

    void Update()
    {
        if(GameController.Instance.IsGameOver()){
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

        if(GameController.Instance.IsGameOver()){
            return;
        }
        
        if(other.CompareTag("Pass")){
            GameController.Instance.ScoreIncrement();
            if(aus&&score){
                aus.PlayOneShot(score);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("floor")){
            GameController.Instance.SetGameOverState(true);
            if(aus&&hit && die){
                aus.PlayOneShot(hit);
                aus.PlayOneShot(die);
            }     
        }

        if(other.gameObject.CompareTag("Pipe")){         
            GameController.Instance.SetGameOverState(true);    
            if(aus&&hit&& die){
                aus.PlayOneShot(hit);
                aus.PlayOneShot(die);
            } 
        }
    }
}

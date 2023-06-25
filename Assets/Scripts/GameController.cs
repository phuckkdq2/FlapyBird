using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Darwin
{
    [SerializeField] protected PipeSpawner pipeSpawner;
    public static GameController Instance { get => instance;}
    [SerializeField] bool m_isGameOver ;
    [SerializeField] int m_score;
    [SerializeField] UIManager m_ui;

    private static GameController instance;
    
          
    private void Awake() {
        GameController.instance = this;
    }
    void Start()
    {   
        this.m_score = 0;
        this.m_ui.ShowHomeGui(true);
        Time.timeScale = 0f;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIManager();
        this.LoadPipeSpawner();
    }

    protected virtual void LoadUIManager()
    {
        if(this.m_ui != null) return;
        this.m_ui = GameObject.FindObjectOfType<UIManager>();
    }

     protected virtual void LoadPipeSpawner()
    {
        if(this.pipeSpawner != null) return;
        this.pipeSpawner = transform.GetComponent<PipeSpawner>();
    }

    public void GamePlay(){
        m_ui.ShowHomeGui(false);
        
        StartCoroutine(PlayingGame());
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(m_isGameOver ){
            Time.timeScale = 0f;
            m_ui.ShowGameOver();                           
        } 
    }

    IEnumerator PlayingGame(){
        while(!m_isGameOver){
            yield return new WaitForSeconds(1.2f);
            pipeSpawner.SpawnPipe();
            }
    }


    public void SetGameOverState(bool state){
        m_isGameOver = state;     
    }

    public bool IsGameOver(){    
        return m_isGameOver;
    }

    public void SetScore(int value){
        m_score = value;
    }

    public int GetScore(){
        return m_score ;
    }

    public void ScoreIncrement(){
        if(m_isGameOver == true){
            return;
        }
        m_score++ ;
        m_ui.ShowScore("SCORE : " + m_score);
    }

    public void Replay(){    
        SceneManager.LoadScene("GamePlay");
    }
    
}

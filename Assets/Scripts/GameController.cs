using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pipe ;
    public float spawntime; 
    bool m_isGameOver ;
    int m_score;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {   
        m_score = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.ShowHomeGui(true);
        Time.timeScale = 0f;
    }

    public void GamePlay(){
        m_ui.ShowHomeGui(false);
        
        StartCoroutine(PlayingGame());
        Time.timeScale = 1f;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(m_isGameOver ){
            Time.timeScale = 0f;
            m_ui.ShowGameOver();
                                
        }
        
    }

    IEnumerator PlayingGame(){
        while(!m_isGameOver){
            yield return new WaitForSeconds(2f);
            SpawnPipe();
            }
    }

    public void SpawnPipe(){
        float randYpos = Random.Range(-2f, 2f);
        Vector2 spanwPipex = new Vector2(4f , randYpos);
        if(pipe){
            Instantiate(pipe , spanwPipex, Quaternion.identity);
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

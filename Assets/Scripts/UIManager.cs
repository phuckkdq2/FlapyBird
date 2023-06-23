using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText ;
    public GameObject gameOverGui;
    public GameObject HomeGui;
    public GameObject GameGui;

    public void ShowScore(string text){
        if(scoreText){
            scoreText.text = text;
        }
    }

    public void ShowHomeGui(bool isShow){
        if(HomeGui){
            HomeGui.SetActive(isShow);
        }
        if(GameGui){
            GameGui.SetActive(!isShow);
        }
    }
    public void ShowGameOver(){
        if(gameOverGui){
            gameOverGui.SetActive(true);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    private GameObject gameplay;
    private GameObject gameOver;
    private GameObject youWin;

    // Start is called before the first frame update
    void Start()
    {
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        gameOver = gameObject.transform.Find("GameOver").gameObject;
        youWin = gameObject.transform.Find("YouWin").gameObject;

    }

    public void setGameOver() {
        gameplay.SetActive(false);
        gameOver.SetActive(true);
    }

        public void setYouWin() {
        gameplay.SetActive(false);
        youWin.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    private GameObject gameplay;
    private GameObject gameOver;
    private GameObject youWin;

    private GameObject player;

    private AudioSource audioSource;
    public AudioClip onLose;
    public AudioClip onWin;

    public int enemies = 6;

    // Start is called before the first frame update
    void Start()
    {
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        gameOver = gameObject.transform.Find("GameOver").gameObject;
        youWin = gameObject.transform.Find("YouWin").gameObject;
        audioSource = GameObject.Find("EventSystem").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        //onLose and onWin must be initialized in Editor
    }

    private void stopBackgroundMusic() {
        audioSource.Stop();
    }

    private void setMusic(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

    public void setGameOver() {
        gameplay.SetActive(false);
        gameOver.SetActive(true);
        stopBackgroundMusic();
        setMusic(onLose);
    }

    public void onEnemyDead(){
        enemies--;
        if(enemies == 0) {
            setYouWin();
        }
    }

    public void setYouWin() {
        player.GetComponent<ThrowObject>().toggleShooting();
        gameplay.SetActive(false);
        youWin.SetActive(true);
        stopBackgroundMusic();
        setMusic(onWin);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    private GameObject gameplay;
    private GameObject gameOver;
    private GameObject youWin;
    private GameObject menu;

    private GameObject player;

    private AudioSource audioSource;
    public AudioClip onLose;
    public AudioClip onWin;

    private bool inMenu = true;

    public int enemies = 6;

    // Start is called before the first frame update
    private void Start()
    {
        gameplay = gameObject.transform.Find("Gameplay").gameObject;
        menu = gameObject.transform.Find("Menu").gameObject;
        gameOver = gameObject.transform.Find("GameOver").gameObject;
        youWin = gameObject.transform.Find("YouWin").gameObject;
        audioSource = GameObject.Find("EventSystem").GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        player.GetComponent<ThrowObject>().toggleShooting(); //Player can't shoot in menu
        //onLose and onWin must be initialized in Editor
    }

    //Espera a la tecla indicada para iniciar el juego
    private void Update() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && inMenu) {
            gameplay.SetActive(true);
            menu.SetActive(false);
            player.GetComponent<ThrowObject>().toggleShooting();
            startBackgroundMusic();
            inMenu = false;
        }
    }

    //Inicia la música de fondo
    private void startBackgroundMusic() {
        audioSource.Play();
    }

    //Para la musica de fondo
    private void stopBackgroundMusic() {
        audioSource.Stop();
    }

    //Reproduce el clip pasado por parámetro
    private void setMusic(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

    //Cambia al panel de Game Over
    public void setGameOver() {
        gameplay.SetActive(false);
        gameOver.SetActive(true);
        stopBackgroundMusic();
        setMusic(onLose);
    }

    //Cuando mueren todos los enemigos cambia a panel de victoria
    public void onEnemyDead(){
        enemies--;
        if(enemies == 0) {
            setYouWin();
        }
    }

    //Cambia al panel de You Win
    public void setYouWin() {
        player.GetComponent<ThrowObject>().toggleShooting();
        gameplay.SetActive(false);
        youWin.SetActive(true);
        stopBackgroundMusic();
        setMusic(onWin);
    }
}

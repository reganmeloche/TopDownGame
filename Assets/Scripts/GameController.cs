using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsPaused() {
        return isPaused;
    }

    public void PauseGame(float timeScale = 0) {
        isPaused = true;
        Time.timeScale = timeScale;
        pauseCanvas.SetActive(true);
        
    }

    // public void PauseForSeconds(float seconds) {
    //     StartCoroutine(PauseForSeconds(seconds));
    // }

    public IEnumerator PauseForSeconds(float seconds) {
        PauseGame(0.0001f);
        yield return new WaitForSeconds(seconds * Time.timeScale);
        UnpauseGame();
    }

    public void UnpauseGame() {
        isPaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

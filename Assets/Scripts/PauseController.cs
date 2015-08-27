using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public GameObject pauseBoard;
    public void Pause()
    {
        Time.timeScale = 0;
        pauseBoard.SetActive(true);
    }
}

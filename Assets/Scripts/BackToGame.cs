using UnityEngine;
using System.Collections;

public class BackToGame : MonoBehaviour
{
    public GameObject pauseBoard;

    public void ClosePauseBoard()
    {
        Time.timeScale = 1;
        pauseBoard.SetActive(false);
    }

}

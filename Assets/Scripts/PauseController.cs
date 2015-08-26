using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_EndScene : MonoBehaviour
{
    

    // Stops the game from running immedietly.
    public void StopGame()
    {
        Debug.Break();
    }

    public void StopAfterTime(float time)
    {
        StartCoroutine(StopGameTime(time));
    }

    IEnumerator StopGameTime(float time)
    {
        yield return new WaitForSeconds(time);

        StopGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPoint : MonoBehaviour
{
    [Tooltip("List of gameObjects that the player can be teleported to.")]
    public List<GameObject> teleportPoints = new List<GameObject>();
    [Tooltip("Direct reference to the player.")]
    public GameObject player = null;

    private bool doOnce = false;

    public void TeleportToLocationAtTime(float time, int pointIndex)
    {
        if (doOnce)
        {
            return;
        }

        StartCoroutine(TimedTeleport(time, pointIndex));
        doOnce = !doOnce;
    }

    IEnumerator TimedTeleport(float time, int pointIndex)
    {
        yield return new WaitForSeconds(time);

        TeleportInstantlyTo(pointIndex);
    }

    public void TeleportInstantlyTo(int pointIndex)
    {
        player.transform.position = teleportPoints[pointIndex].transform.position;
        player.transform.rotation = teleportPoints[pointIndex].transform.rotation;

        doOnce = false;
    }
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            GameObject trigger = GetNearestActiveCheckpoint();

            if(trigger != null && collider.gameObject.GetComponent<PlayerStats>().isDead == false)
            {
                Vector3 positionOffset = trigger.transform.position;
                positionOffset.y = 5;

                collider.transform.position = positionOffset;
            }
            else
            {
                Debug.LogError("No valid checkpoint was found!");
            }
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }

    GameObject GetNearestActiveCheckpoint()
    {
        GameObject[] checkPoints =
            GameObject.FindGameObjectsWithTag("Checkpoint");

        GameObject nearestCheckPoint = null;
        float shortestDistance = Mathf.Infinity;

        foreach(GameObject checkpoint in checkPoints)
        {
            Vector3 checkpointPosition = checkpoint.transform.position;
            float distance =
                (checkpointPosition - transform.position).sqrMagnitude;

            CheckpointTrigger trigger = 
                checkpoint.GetComponent<CheckpointTrigger>();

            if(distance < shortestDistance && trigger.isTriggered)
            {
                nearestCheckPoint = checkpoint;
                shortestDistance = distance;
            }
        }

        return nearestCheckPoint;
    }
}

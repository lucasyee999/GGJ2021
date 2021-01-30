using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController control = other.GetComponent<PlayerController>();
            control.theSpeed = (control.runSpeed / 100) * 60;
        }
        else if(other.tag == "Enemy")
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.ActualChaseSpeed = (enemyController.ChaseMovementSpeed / 100) * 60;
            enemyController.ActualPatrolSpeed = (enemyController.PatrolMovementSpeed / 100) * 60;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController control = other.GetComponent<PlayerController>();
            control.theSpeed = control.runSpeed;
        }
        else if(other.tag == "Enemy")
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.ActualChaseSpeed = enemyController.ChaseMovementSpeed;
            enemyController.ActualPatrolSpeed = enemyController.PatrolMovementSpeed;
        }
    }



}

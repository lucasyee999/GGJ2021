using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private EnemyController _enemyController;


    private void Start()
    {
        _enemyController = GetComponentInParent<EnemyController>();
        _enemyController.coneCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Physics2D.Raycast(_enemyController.transform.position, (other.transform.position - _enemyController.transform.position)))
            {
                _enemyController.OnEnter(other);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemyController.OnExit(other);
        }
    }
}

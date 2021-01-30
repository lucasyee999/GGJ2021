using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private EnemyController _enemyController;

    private Transform transformer;


    private void Start()
    {
        _enemyController = GetComponentInParent<EnemyController>();
        _enemyController.coneCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, other.transform.position - _enemyController.transform.position, 1000f, LayerMask.NameToLayer("NonDetection"));
            if (hit.collider.CompareTag("Player") || hit.collider.tag == "Player")
            {
                _enemyController.OnEnter(other);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _enemyController.OnExit(other);
        }
    }
}

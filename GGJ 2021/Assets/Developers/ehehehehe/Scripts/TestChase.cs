using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Lucas
{
    public class TestChase : MonoBehaviour
    {
        public GameObject target;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Update()
        {

            _agent.SetDestination(target.transform.position);

        }

    }
}

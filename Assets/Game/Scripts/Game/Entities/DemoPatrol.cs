using System;
using UnityEngine;

namespace Game.Entities
{
    public class DemoPatrol : MonoBehaviour
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float distance;
        [SerializeField] private float force;

        private Vector3 endPosition;
        private Vector3 startPosition;
        private Rigidbody rigidbody;
        
        private enum State
        {
            start,
            end
        }

        private State state;
        
        public void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            endPosition = transform.position + direction * distance;
            startPosition = transform.position;
            state = State.start;
        }

        public void Update()
        {
            Move();
        }


        private void Move()
        {
            if (state == State.start)
            {
                rigidbody.AddForce(direction * force, ForceMode.Force);
                if (Vector3.Distance(transform.position, endPosition) <= 0.5f)
                {
                    state = State.end;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, startPosition) <= 0.5f)
                {
                    state = State.start;
                }
                rigidbody.AddForce(-direction * force, ForceMode.Force);
            }
        }
    }
}
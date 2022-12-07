using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector3 direction;
        [SerializeField] private List<Rigidbody> rigidbody;
        private InputSystem inputSystem;
        private int amountBones;
        // private float deltaSpeed;

        private void Awake()
        {
            direction = new Vector3();
            amountBones = rigidbody.Count;
            // deltaSpeed = speed * Time.fixedDeltaTime;
        }

        private void Start()
        {
            inputSystem = GetComponent<InputSystem>();
            inputSystem.OnDirectionInputActionPlayer += UpdateDir;
        }

        private void OnDestroy()
        {
            inputSystem.OnDirectionInputActionPlayer -= UpdateDir;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            for (int i = 0; i < amountBones; i++)
            {
                rigidbody[i].AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Force);
            }
        }

        [SerializeField] private Transform p; 
        private void UpdateDir(float x, float  y)
        {
            direction.x = x;
            direction.z = y;
            if (x == 0 && y == 0)
            {
                return;
            }
            float angle = 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            p.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
using System;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class FollowerSystem : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 offset;
        
        private void Start()
        {
            offset = transform.localPosition - target.localPosition;
        }

        private void FixedUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            transform.localPosition = new Vector3(target.localPosition.x + offset.x, target.localPosition.y, target.localPosition.z + offset.z);
        }
    }
}
using System;
using UnityEngine;

namespace Game.Entities
{
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] protected float force;
        [SerializeField] protected Rigidbody[] rigidbodyRoller;
        [SerializeField] protected Transform hip;
            protected ushort amountBones;
        protected float deltaForce;
        protected Vector3 direction;
        protected Vector3 directionT;
        private void Awake()
        {
            direction = new Vector3();
            amountBones = (ushort)rigidbodyRoller.Length;
            deltaForce = force * Time.fixedDeltaTime;
        }
        
        private void FixedUpdate()
        {
            Move();
        }
        
        public void Move()
        {
            // if (direction.z <= -0.5)
            // {
            //     directionT = new Vector3(Mathf.Lerp(directionT.x, direction.x, 0.05f),
            //         Mathf.Lerp(directionT.y, direction.y, 1f), Mathf.Lerp(directionT.z, -0.5f, 0.2f)); 
            // }
            // else
            // {
                directionT = new Vector3(Mathf.Lerp(directionT.x, direction.x, 0.05f),
                    Mathf.Lerp(directionT.y, direction.y, 1f), Mathf.Lerp(directionT.z, direction.z, 0.2f));
            // }
            // Debug.Log(direction);
            for (ushort i = 0; i < amountBones; i++)
            {
                rigidbodyRoller[i].AddForce(directionT * deltaForce, ForceMode.Force);
            }
            if (directionT.x == 0 && directionT.y == 0)
            {
                return;
            }
            Rotate();
        }
        
        private void Rotate()
        {
            Quaternion OriginalRot = hip.rotation;
            hip.rotation = Quaternion.Euler(0, 90 - Mathf.Atan2(directionT.z, directionT.x) * Mathf.Rad2Deg, 0);
            Quaternion NewRot = hip.rotation;
            hip.rotation = OriginalRot;
            hip.rotation = Quaternion.Lerp(hip.rotation, NewRot, 0.2f);
            // hip.transform.forward = directionT.normalized;
            // hip.rotation = rigidbodyRoller[0].transform.forward.normalized;//Quaternion.Euler(0, 90 - Mathf.Atan2(directionT.z, directionT.x) * Mathf.Rad2Deg, 0);
        }
    }
}
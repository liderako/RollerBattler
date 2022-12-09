using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public struct LerpActorSettings
    {
        public float lerpX;
        public float lerpZ;
    }
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] protected float force;
        [SerializeField] protected Rigidbody[] rigidbodyRoller;
        [SerializeField] protected Transform hip;
        [SerializeField] private float maximumSpeed;
        [SerializeField] private LerpActorSettings lerpActorSettings; 
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

        private float lerpZ;
        private float lerpX;
        
        public void Move()
        {
            if (direction.z <= 0.25 && direction.z >= -0.25)
            {
                lerpZ = lerpActorSettings.lerpZ * 2;
            }
            else
            {
                lerpZ = lerpActorSettings.lerpZ;
            }
            if (direction.x <= 0.25 && direction.x >= -0.25)
            {
                lerpX = lerpActorSettings.lerpX * 2;
            }
            else
            {
                lerpX = lerpActorSettings.lerpX;
            }
            directionT = new Vector3(Mathf.Lerp(directionT.x, direction.x,  lerpActorSettings.lerpX),
                    direction.y, Mathf.Lerp(directionT.z, direction.z, lerpActorSettings.lerpZ));
            for (ushort i = 0; i < amountBones; i++)
            {
                rigidbodyRoller[i].AddForce(directionT * deltaForce, ForceMode.Force);
            }
            if (directionT.x == 0 && directionT.y == 0)
            {
                return;
            }
            Rotate();
            LimitVelocity();
        }

        private void LimitVelocity()
        {
            for (ushort i = 0; i < amountBones; i++)
            {
                float speed = Vector3.Magnitude (rigidbodyRoller[i].velocity); 
      
                if (speed > maximumSpeed)
                {
                    float brakeSpeed = speed - maximumSpeed;  // calculate the speed decrease
 
                    Vector3 normalisedVelocity = rigidbodyRoller[i].velocity.normalized;
                    Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value
 
                    rigidbodyRoller[i].AddForce(-brakeVelocity * deltaForce, ForceMode.Force);  // apply opposing brake force
                }
            }
        }
        
        private void Rotate()
        {
            Quaternion OriginalRot = hip.rotation;
            hip.rotation = Quaternion.Euler(0, 90 - Mathf.Atan2(directionT.z, directionT.x) * Mathf.Rad2Deg, 0);
            Quaternion NewRot = hip.rotation;
            hip.rotation = OriginalRot;
            hip.rotation = Quaternion.Lerp(hip.rotation, NewRot, 0.2f);
        }
    }
}
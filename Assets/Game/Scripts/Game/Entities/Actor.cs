using UnityEngine;

namespace Game.Entities
{
    public abstract class Actor : MonoBehaviour
    {
        [SerializeField] protected float force;
        [SerializeField] protected Rigidbody[] rigidbodyRoller;
        protected ushort amountBones;
        protected float deltaForce;
        protected Vector3 direction;
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
            for (ushort i = 0; i < amountBones; i++)
            {
                rigidbodyRoller[i].AddForce(direction * deltaForce, ForceMode.Force);
            }
        }
    }
}
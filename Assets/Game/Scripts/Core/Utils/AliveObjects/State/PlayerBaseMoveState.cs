using System.Collections;
using System.Collections.Generic;
using CoreGame.Managers;
using CoreGame.Utils.Interface;
using UnityEngine;

namespace CoreGame.Utils.AliveObject.State
{
    public class PlayerBaseMoveState : MonoBehaviour, IState, IEnabledState, IMoveableState
    {
        protected float speedMove;
        protected float speedRotate;
        protected Vector2 direction;

        private void Start()
        {
            speedMove = GameManager.Instance.Settings.PlayerSettings.SpeedMove;
            speedRotate = GameManager.Instance.Settings.PlayerSettings.SpeedRotate;
        }

        public virtual void UpdateState()
        {
            Move();
        }

        public virtual void Enable()
        {
            InputManager.Instance.OnMove += UpdateDirection;
        }

        public virtual void Disable()
        {
            InputManager.Instance.OnMove -= UpdateDirection;
        }
        
        public virtual void Move()
        {
            transform.position += new Vector3(direction.x, 0, direction.y) * speedMove * Time.deltaTime;
            Rotate();
        }

        protected void Rotate()
        {
            Quaternion OriginalRot = transform.rotation;
            float angle = 90 - Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle + 90, 0);
            Quaternion NewRot = transform.rotation;
            transform.rotation = OriginalRot;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, speedRotate);
        }

        public void UpdateDirection(Vector2 direction)
        {
            this.direction = direction;
        }
    }
}
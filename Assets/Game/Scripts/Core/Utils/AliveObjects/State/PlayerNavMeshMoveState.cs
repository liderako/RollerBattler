using System.Collections;
using System.Collections.Generic;
using CoreGame.Managers;
using UnityEngine.AI;

namespace CoreGame.Utils.AliveObject.State
{
    public class PlayerMoveState : PlayerBaseMoveState
    {
        public override void Enable()
        {
            InputManager.Instance.OnMove += UpdateDirection;
            GetComponent<NavMeshAgent>().enabled = true;
        }

        public override void Disable()
        {
            InputManager.Instance.OnMove -= UpdateDirection;
            GetComponent<NavMeshAgent>().enabled = false;
        }
        
        public override void Move()
        {
            if (GetComponent<NavMeshAgent>().enabled == false)
            {
                return;
            }
            GetComponent<NavMeshAgent>().destination = transform.position + transform.forward * 2f; // TO Do what is 2?
            Rotate();
        }
    }
}
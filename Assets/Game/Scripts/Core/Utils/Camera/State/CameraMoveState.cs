using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Utils.Interface;

namespace CoreGame.Camera.State
{
    public class CameraMoveState : IState
    {
        private Vector3 offset;
        private Transform ownerTransform;
        private Transform targetTransform;
        private float speed = 10;
        
        public CameraMoveState(Transform transformTarget, Transform ownerTransform)
        {
            this.ownerTransform = ownerTransform;
            this.targetTransform = transformTarget;
            this.offset = ownerTransform.localPosition - transformTarget.localPosition;
        }

        public void UpdateState()
        {
            ownerTransform.position = Vector3.MoveTowards(ownerTransform.position,
                targetTransform.position,
                speed * Time.deltaTime);
        }
    }
}
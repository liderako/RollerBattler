using System.Collections;
using System.Collections.Generic;
using CoreGame.Utils.Interface;
using UnityEngine;

namespace CoreGame.AliveObject
{
    public class BasePlayer : MonoBehaviour, IStatableObject
    {
        private IEnabledState[] enabledStates;
        private IState mainState;

        protected virtual void Awake()
        {
            IEnabledState[] enabledStates = gameObject.GetComponents<IEnabledState>();
            this.enabledStates = new IEnabledState[enabledStates.Length];
            for (int i = 0; i < enabledStates.Length; i++)
            {
                this.enabledStates[i] = enabledStates[i];
            }
        }
        
        public virtual void ChangeState(IState state)
        {
            for (int i = 0; i < enabledStates.Length; i++)
            {
                enabledStates[i].Disable();
            }
            mainState = state;
        }
        
        protected virtual void Update()
        {
            if (mainState == null)
            {
                return;
            }
            mainState.UpdateState();
        }
    }
}
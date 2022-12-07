using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Utils.Interface
{
    public abstract class ABaseState : MonoBehaviour, IEnabledState, IState
    {
        public abstract void UpdateState();
        public abstract void Enable();
        public abstract void Disable();
    }
}
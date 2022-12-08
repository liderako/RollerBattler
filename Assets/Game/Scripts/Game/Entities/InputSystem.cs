using System;
using UnityEngine;

namespace Game.Entities
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        public Action<float,float> OnDirectionInputActionPlayer;

        public void Update()
        {
            if (OnDirectionInputActionPlayer != null)
            {
                OnDirectionInputActionPlayer(joystick.Horizontal, joystick.Vertical);
            }
        }
    }
}
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
                // if (joystick.Horizontal == 0 && joystick.Vertical == 0)
                // {
                //     return;
                // }
                OnDirectionInputActionPlayer(joystick.Horizontal, joystick.Vertical);
            }
        }
    }
}
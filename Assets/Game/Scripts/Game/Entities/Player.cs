using UnityEngine;

namespace Game.Entities
{
    public class Player : Actor
    {
        private InputSystem inputSystem;

        private void Start()
        {
            inputSystem = GetComponent<InputSystem>();
            inputSystem.OnDirectionInputActionPlayer += UpdateDir;
        }

        private void OnDestroy()
        {
            inputSystem.OnDirectionInputActionPlayer -= UpdateDir;
        }

        protected void UpdateDir(float x, float  y)
        {
            direction.x = x;
            direction.z = y;
        }
    }
}
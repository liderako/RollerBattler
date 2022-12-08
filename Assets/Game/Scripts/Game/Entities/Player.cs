using UnityEngine;

namespace Game.Entities
{
    public class Player : Actor
    {
        [SerializeField] private Transform hip; 
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
            if (x == 0 && y == 0)
            {
                return;
            }
            Rotate();
        }

        private void Rotate()
        {
            hip.rotation = Quaternion.Euler(0, 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg, 0);
        }
    }
}
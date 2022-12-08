using System;
using UnityEngine;

namespace Game.Entities
{
    public class ShooSystem : MonoBehaviour
    {
        [SerializeField] private Transform spriteRight;
        [SerializeField] private float d;
        private float stepP = 0.3f;
        private float stepS = 0.5f;
        private float stepSX = 0.1f;

        private void Start()
        {
        }

        private void Update()
        {
            if (spriteRight.localScale.y < d)
            {
                spriteRight.transform.position = Vector3.Lerp(spriteRight.transform.position,
                    new Vector3(spriteRight.transform.position.x + stepP, spriteRight.transform.position.y,
                        spriteRight.transform.position.z), 0.5f);
                spriteRight.transform.localScale = Vector3.Lerp(spriteRight.transform.localScale,
                    new Vector3(spriteRight.transform.localScale.x + stepSX, spriteRight.transform.localScale.y + stepS,
                        spriteRight.transform.localScale.z), 0.5f);
            }
        }
    }
}
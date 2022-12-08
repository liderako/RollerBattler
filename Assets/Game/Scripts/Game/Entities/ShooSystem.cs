using System;
using UnityEngine;

namespace Game.Entities
{
    public class ShooSystem : MonoBehaviour
    {
        [SerializeField] private Transform spriteRight;
        [SerializeField] private float d;
        [SerializeField] private float stepP = 0.3f;
        [SerializeField] private float stepS = 0.5f;
        [SerializeField] private float stepSX = 0.1f;

        private void Start()
        {
        }

        private void Update()
        {
            if (spriteRight.localScale.y < d)
            {
                spriteRight.transform.localPosition = Vector3.Lerp(spriteRight.transform.localPosition,
                    new Vector3(spriteRight.transform.localPosition.x + stepP, spriteRight.transform.localPosition.y,
                        spriteRight.transform.localPosition.z), 1f);
                spriteRight.transform.localScale = Vector3.Lerp(spriteRight.transform.localScale,
                    new Vector3(spriteRight.transform.localScale.x + stepSX, spriteRight.transform.localScale.y + stepS,
                        spriteRight.transform.localScale.z), 1f);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    public class ShooSystem : MonoBehaviour
    {
        [SerializeField] private Transform spriteRight;
        [SerializeField] private float maxScale;
        [SerializeField] private float stepP = 0.3f;
        [SerializeField] private float stepS = 0.5f;
        [SerializeField] private float stepSX = 0.1f;

        [SerializeField] private List<Transform> enemies;
        
        private float originScale;

        private void Awake()
        {
            originScale = maxScale;
        }

        private void Start()
        {
        }

        private void Update()
        {
            if (CheckEnemyInRange())
            {
                RenderVision(true);
            }
            else
            {
                RenderVision(false);   
            }
        }

        [SerializeField] private Transform owner;
        [SerializeField] private float yStart;
        [SerializeField] private float step = 5.0f;
        [SerializeField] private int amountRay = 5;
        [SerializeField] private float rangeVision = 30;
        private bool CheckEnemyInRange()
        {
            float yStartTMP = yStart;
            RaycastHit hit;

            for (int i = 0; i < amountRay; i++)
            {
                Vector3 dir = Quaternion.Euler(0, yStartTMP, 0) * (owner.right * rangeVision);
                Debug.DrawRay(owner.position, dir, Color.yellow);
                if (Physics.Raycast(owner.position, dir, out hit, rangeVision))
                {
                    // if (hit.collider.TryGetComponent())
                    Debug.DrawRay(owner.position, dir, Color.black);
                    return true;
                }
                yStartTMP += step;
            }
            return false;
        }

        private void RenderVision(bool state)
        {
            if (state && spriteRight.localScale.y < maxScale)
            {
                ChangeLocalPosition(stepP);
                ChangeScale(stepSX, stepS);
            }
            else if (!state && spriteRight.localScale.y > originScale)
            {
                ChangeLocalPosition(-stepP);
                ChangeScale(-stepSX, -stepS);
            }
        }

        private void ChangeLocalPosition(float tmpX)
        {
            spriteRight.transform.localPosition = Vector3.Lerp(spriteRight.transform.localPosition,
                new Vector3(spriteRight.transform.localPosition.x + tmpX, spriteRight.transform.localPosition.y,
                    spriteRight.transform.localPosition.z), 1f);
        }

        private void ChangeScale(float tmpX, float tmpY)
        {
            spriteRight.transform.localScale = Vector3.Lerp(spriteRight.transform.localScale,
                new Vector3(spriteRight.transform.localScale.x + tmpX, spriteRight.transform.localScale.y + tmpY,
                    spriteRight.transform.localScale.z), 1f);
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public struct RaySettings
    {
        public float yStart;
        public float step;
        public int amountRay;
        public float rangeVision;
        public LayerMask layerMask;
        public bool isLeft;
    }

    [Serializable]
    public struct RenderSettings
    {
        public float sub;
        public float add;
        public float maxScale;
        public float stepP;
        public float stepS;
        public float stepSX;
    }
    
    public class ShootSystem : MonoBehaviour
    {
        [SerializeField] private RaySettings raySettings;
        [SerializeField] private RenderSettings renderSettings;
        [SerializeField] private Weapon weapon;
        private float originScale;
        private Vector3 dirTriangle;

        [SerializeField] private Transform owner;
        private SpriteRenderer spriteRenderer;
        private Color originColor;
        private RaycastHit hit;
        
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originScale = transform.localScale.y;
            originColor = spriteRenderer.color;
            spriteRenderer.color = new Color(r: spriteRenderer.color.r, g: spriteRenderer.color.g,
                b: spriteRenderer.color.b, a: 0);
        }

        private void Update()
        {
            if (CheckEnemyInRange())
            {
                RenderVision(true);
                if (IsReadyToShot())
                {
                    Shot(); 
                }
            }
            else
            {
                RenderVision(false);   
            }
        }
        private bool CheckEnemyInRange()
        {
            float yStartTMP = raySettings.yStart;

            for (int i = 0; i < raySettings.amountRay; i++)
            {
                if (raySettings.isLeft)
                {
                    dirTriangle = -owner.right;
                }
                else
                {
                    dirTriangle = owner.right;
                }
                Vector3 dir = Quaternion.Euler(0, yStartTMP, 0) * dirTriangle * raySettings.rangeVision;
                Debug.DrawRay(owner.position, dir, Color.yellow);
                if (Physics.Raycast(owner.position, dir, out hit, raySettings.rangeVision, raySettings.layerMask))
                {
                    Debug.DrawRay(owner.position, dir, Color.black);
                    return true;
                }
                yStartTMP += raySettings.step;
            }
            return false;
        }

        private void Shot()
        {
            if (weapon == null)
            {
                return;   
            }
            if (raySettings.isLeft)
            {
                weapon.Shot(-owner.right);
            }
            else
            {
                weapon.Shot(owner.right);
            }
        }

        private bool IsReadyToShot()
        {
            if (weapon != null && weapon.IsReady) 
            {
                // if (transform.localScale.y >= renderSettings.maxScale - (renderSettings.maxScale * 0.15))
                if (spriteRenderer.color.a >= originColor.a - originColor.a * 0.15)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void RenderVision(bool state)
        {
            if (state) //&& transform.localScale.y < renderSettings.maxScale)
            {
                // if (transform.localScale.y < renderSettings.maxScale)
                // {
                //     ChangeLocalPosition(renderSettings.stepP);
                //     ChangeScale(renderSettings.stepSX, renderSettings.stepS);   
                // }
                if (spriteRenderer.color.a < originColor.a)
                {
                    ChangeAlphaCanal(true);
                }
            }
            else if (!state)//&& transform.localScale.y > originScale)
            {
                // if (transform.localScale.y > originScale)
                // {
                //     ChangeLocalPosition(-renderSettings.stepP);
                //     ChangeScale(-renderSettings.stepSX, -renderSettings.stepS);   
                // }
                if (spriteRenderer.color.a > 0)
                {
                    ChangeAlphaCanal(false);
                }
            }
        }
        
        private void ChangeAlphaCanal(bool state)
        {
            if (state)
            {
                spriteRenderer.color = new Color(r: spriteRenderer.color.r, g: spriteRenderer.color.g,
                    b: spriteRenderer.color.b, a: Mathf.Lerp(spriteRenderer.color.a, originColor.a, renderSettings.sub * Time.deltaTime));
            }
            else
            {
                spriteRenderer.color = new Color(r: spriteRenderer.color.r, g: spriteRenderer.color.g,
                    b: spriteRenderer.color.b, a: Mathf.Lerp(spriteRenderer.color.a, 0, renderSettings.sub * Time.deltaTime));   
            }
        }

        // private void ChangeLocalPosition(float tmpX)
        // {
        //     transform.localPosition = Vector3.Lerp(transform.localPosition,
        //         new Vector3(transform.localPosition.x + tmpX, transform.localPosition.y,
        //             transform.localPosition.z), 0.1f);
        // }
        //
        // private void ChangeScale(float tmpX, float tmpY)
        // {
        //     transform.localScale = Vector3.Lerp(transform.localScale,
        //         new Vector3(transform.localScale.x + tmpX, transform.localScale.y + tmpY,
        //             transform.localScale.z), 0.1f);
        // }
    }
}
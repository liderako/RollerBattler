using System;
using System.Collections;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public struct WeaponSettings
    {
        public float forceShot;
        public float duration;
        public int damage;
        public float coolDown;
    }

    public class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject prefabBullet;
        [SerializeField] private WeaponSettings settings;
        private Transform parent;
        public bool IsReady { private set; get; }
        
        private void Start()
        {
            IsReady = true;
            parent = Camera.main.transform;
        }

        public void Shot(Vector3 direction)
        {
            GameObject bullet = Instantiate(prefabBullet, parent.parent);
            bullet.transform.position = transform.position + direction;
            bullet.SetActive(true);
            bullet.transform.forward = direction.normalized;
            bullet.transform.Rotate(Vector3.right, -90);
            bullet.layer = gameObject.layer;
            bullet.GetComponent<Rigidbody>().AddForce(direction * settings.forceShot, ForceMode.Impulse);
            Destroy(bullet, settings.duration);
            StartCoroutine(CoolDown());
        }

        IEnumerator CoolDown()
        {
            IsReady = false;
            yield return new WaitForSecondsRealtime(settings.coolDown);
            IsReady = true;
        }
    }
}
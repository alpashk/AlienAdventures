using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Weapons.Visuals
{
    public class Tracer : MonoBehaviour
    {
        [SerializeField] private float speed = 2.0f;
        private void Start()
        {
            StartCoroutine(DestroyAfterTime());
        }

        private void Update()
        {
            transform.Translate(Vector3.right * speed);
        }

        IEnumerator DestroyAfterTime()
        {
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}
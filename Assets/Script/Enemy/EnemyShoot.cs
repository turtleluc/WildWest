using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Aitest 
{
    public class EnemyShoot : MonoBehaviour
    {

        [SerializeField] private Transform muzzle;

        public Transform shootingPoint;

        public Transform gunPoint;

        public LayerMask Layermask;

        [Header("Gun")]

        public Vector3 spread = new Vector3(0.06f, 0.06f, 0.06f);

        public TrailRenderer bullettrail;

        private AIRefrences airefrences;

        void Awake()
        {
            airefrences = GetComponent<AIRefrences>();
        }

        public void Shoot()
        {
            Vector3 direction = GetDirection();
            if (Physics.Raycast(shootingPoint.position, direction, out RaycastHit hit, float.MaxValue, Layermask))
            {
                Debug.DrawLine(shootingPoint.position, shootingPoint.position + direction * 10f, Color.red, 1f);

                TrailRenderer trail = Instantiate(bullettrail, gunPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit));

            }

        }

        private Vector3 GetDirection()
        {
            Vector3 direction = transform.forward;
            direction += new Vector3(
                Random.Range(-spread.x, spread.x),
                Random.Range(-spread.y, spread.y),
                Random.Range(-spread.z, spread.z));

            direction.Normalize();
            return direction;

        }

        private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
        {
            float time = 0f;
            Vector3 startposition = trail.transform.position;

            while (time < 1f)
            {
                trail.transform.position = Vector3.Lerp(startposition, hit.point, time);
                time += Time.deltaTime / trail.time;

                yield return null;
            }
            trail.transform.position = hit.point;
            Destroy(trail.gameObject, trail.time);
        }
    }
}

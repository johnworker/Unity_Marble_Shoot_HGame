using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class ShootRay : MonoBehaviour
    {
        public Transform gunEnd;
        public float range = 50f;
        public LayerMask hitMask;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Ray ray = new Ray(gunEnd.position, gunEnd.forward);
            /*
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo, range, hitMask))
            {
                Debug.Log("Hit " + hitInfo.collider.gameObject.name);
                // ����A�ΩR���޿�
            }
            else
            {
                Debug.Log("Miss");
                // ����A�Υ��R���޿�
            }
            */
        }
    }
}
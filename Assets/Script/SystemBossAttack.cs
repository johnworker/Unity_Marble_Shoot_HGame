using System.Collections;
using UnityEngine;

namespace LEO
{
    public class SystemBossAttack : MonoBehaviour
    {
        // ���{��������g���w�s��
        public GameObject projectilePrefab;
        // ���{�������_�l��m
        public Transform attackPoint;
        // ��g�����t��
        public float projectileSpeed = 10f;
        // ���{���������j�ɶ�
        public float attackInterval = 2f;
        // ����O�_�i�H�i�滷�{����
        private bool canAttack = true; 

        private void Start()
        {
            // �b Start ��k���Ұʻ��{������{
            StartCoroutine(BossAttackCoroutine());
        }

        private IEnumerator BossAttackCoroutine()
        {
            while (true)
            {
                if (canAttack)
                {
                    // �Ыا�g��
                    GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

                    // �]�m��g�����t�שM��V
                    Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                    projectileRb.velocity = transform.right * projectileSpeed;

                    // ���ݧ������j�ɶ�
                    yield return new WaitForSeconds(attackInterval);
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}
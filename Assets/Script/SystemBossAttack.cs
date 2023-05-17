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
        private bool canAttack = false;

        private void Start()
        {
            // �b Start ��k���Ұʻ��{������{
            StartCoroutine(BossAttackCoroutine());
        }

        // �ݧ⪱�a�@�������ؼЦӥB�ĤH�^�X�~�����@��

        public IEnumerator BossAttackCoroutine()
        {
            while (true)
            {
                if (canAttack)
                {
                    // �Ыا�g��
                    GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

                    // �]�m��g�����t�שM��V
                    Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                    projectileRb.velocity = transform.right * projectileSpeed;

                    // ��쪱�a����
                    GameObject player = GameObject.FindWithTag("Player");

                    // �p�G��쪱�a����A�N�]���������ؼг]�w�����a����m
                    if (player != null)
                    {
                        Vector3 playerPosition = player.transform.position;
                        playerPosition.z = transform.position.z;
                        Vector3 direction = (playerPosition - attackPoint.position).normalized;
                        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
                        // 3D��q�y�������a����
                    }

                    // ���ݧ������j�ɶ�
                    yield return new WaitForSeconds(attackInterval);

                    // �ĤH�������ᵲ�������^�X
                    canAttack = false;
                }
                else
                {
                    yield return null;
                }
            }
        }

        public void StartBossAttack()
        {
            // �b�ĤH�^�X�}�l�ɩI�s�o�Ӥ�k�A�}�l�]���������^�X
            canAttack = true;
        }
    }
}
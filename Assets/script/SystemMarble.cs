using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// �u�]�t��
    /// 1.���ɶ��S���I��Ǫ��N���U��^��
    /// </summary>
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ��ϼh")]
        private LayerMask layerEnemy;
        [SerializeField, Header("�X��S���I��Ǫ��n�^��"), Range(0, 10)]
        private float timeRecycle = 3;
        [SerializeField, Header("�^���t��")]
        private Vector3 v3SpeedRecycle;

        private float timer;
        private bool timerRun;



        /* 1.�����u�]�O�_�I���Ǫ��ϼh���Ǫ�
         * 2.�S���I���Ǫ��h�[��^��
         */

        private void OnCollisionEnter(Collision collision)
        {
            if ((layerEnemy & (1 << collision.gameObject.layer)) != 0)
            {
                // �I��Ǫ����^��
                timer = 0f;
            }

            /* �ĤG�ؼg�k
             * if (collision.gameObject.layer == LayerMask.NameToLayer("�Ǫ�"))
            {
                // �I��Ǫ����^��
                timer = 0f;
            }
             */
        }

        private void FixedUpdate()
        {
            // �p�G�p�ɾ��]�ʥ��} �h��^
            if (!timerRun) return;
            // �p�ɻ��W
            timer += Time.fixedDeltaTime;


            if (timer >= timeRecycle)
            {
                // �^��
                transform.Translate(v3SpeedRecycle * Time.fixedDeltaTime);
                if (transform.position.z < -20f)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        // �ҥε{����
        private void OnEnable()
        {
            // �p�ɾ��]�ʶ}��
            timerRun = true;
            // �p���k�s
            timer = 0f;
        }

        // �{���B�൲����
        private void OnDisable()
        {
            // �p�ɾ��]������
            timerRun = false;
        }
    }

}

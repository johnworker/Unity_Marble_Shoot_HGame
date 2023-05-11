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

        #region ���
        [SerializeField, Header("�Ǫ��ϼh")]
        private LayerMask layerEnemy;
        [SerializeField, Header("�X��S���I��Ǫ��n�^��"), Range(0, 10)]
        private float timeRecycle = 3;
        [SerializeField, Header("�^���t��")]
        private Vector3 v3SpeedRecycle;

        private float timer;
        private bool timerRun;

        #endregion


        /* 1.�����u�]�O�_�I���Ǫ��ϼh���Ǫ�
         * 2.�S���I���Ǫ��h�[��^��
         */

        #region �ƥ�
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

        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            // layerEnemy �O�Ψӳ]�w�Ǫ��ϼh���ܼơC
            // 1 << collision.gameObject.layer �O�N�I�����󪺹ϼh�s���ഫ���G�i��A�æV���첾 1 ��A�]�� layerEnemy �]�O�@�ӤG�i��Ʀr�A�ҥH�i�H�i��줸�B��C
            // layerEnemy & (1 << collision.gameObject.layer) �N�O�N��ӤG�i��Ʀr�i��줸�B��A�u�����ӼƦr�������줸���O 1 �ɡA���G�~�|�O 1�C
            // �p�G���G�O 0�A��ܸI���쪺���󤣬O�Ǫ��ϼh�A��������Ʊ��C
            //�p�G���G���O 0�A��ܸI���쪺����O�Ǫ��ϼh�A�N�N�p�ɾ��k�s�A���u�]���|�Q�^���C

            /* // �Ĥ@�ؼg�k
            if ((layerEnemy & (1 << collision.gameObject.layer)) != 0)
            {
                // �I��Ǫ����^��
                timer = 0f;
            }
            */

            // �ĤG�ؼg�k
             if (collision.gameObject.layer == LayerMask.NameToLayer("�Ǫ�"))
            {
                // �I��Ǫ����^��
                timer = 0f;
            }
             
        }

    }

}

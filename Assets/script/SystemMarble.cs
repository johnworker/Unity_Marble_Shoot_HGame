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

        private float moveDistance = -20;


        /* 1.�����u�]�O�_�I���Ǫ��ϼh���Ǫ�
         * 2.�S���I���Ǫ��h�[��^��
         */

        private void Awake()
        {
            StartNewTiming();
        }

        private void Update()
        {
            timer += Time.deltaTime;
        }

        public void StartNewTiming()
        {
            timerRun = true;
            timer = 0;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("�Ǫ�"))
            {

                print(timer);
                if (timer == timeRecycle)
                {
                    StartCoroutine(Move());
                }

            }

        }

        private IEnumerator Move()
        {
            //print(gameObject + "���e����");
            float moveCount = 10;
            float perDistance = moveDistance / moveCount;

            for (int i = 0; i < moveCount; i++)
            {
                transform.position -= new Vector3(0, 0, perDistance);

            }

            yield return new WaitForSeconds(0.1f);


        }
    }

}

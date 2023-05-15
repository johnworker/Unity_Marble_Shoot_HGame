using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// ���ʨt��
    /// </summary>
    public class SystemMove : MonoBehaviour
    {
        private SystemTurn systemTurn;
        private float moveDistance = 2;

        public int Length { get; internal set; }

        private void Awake()
        {
            systemTurn = GameObject.Find("�^�X�t��").GetComponent<SystemTurn>();
            systemTurn.onTurnEnemy.AddListener(() => { StartCoroutine(Move()); });
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

            yield return new WaitForSeconds(1.5f);

            systemTurn.MoveEndSpawnEnemy();

        }

        // ���} ���L�� �ĤH��k()
        public bool HasEnemy()
        {
            return transform.childCount > 0; // �p�G��l�����l����A��ܦ��Ǫ��s�b
        }

    }

}

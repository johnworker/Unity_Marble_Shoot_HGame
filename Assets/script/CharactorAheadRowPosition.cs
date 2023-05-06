using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

namespace LEO
{
    public class CharactorAheadRowPosition : MonoBehaviour
    {
        #region ���
        [Header("�ʧ@��l����e�@�Ʈy��"), SerializeField]
        private Transform[] traCharatorAheadRowPlace;

        public GameObject[] aheadEnemy;

        [SerializeField, Header("�ĤH�ʵe����")]
        private Animator aniEnemy;
        private string parDamage = "Ĳ�o����";

        #endregion


        #region �ƥ�
        private void Awake()
        {
            traCharatorAheadRowPlace = GetComponent<Transform[]>();
        }

        void Update()
        {

        }
        #endregion

        #region ��k
        /// <summary>
        /// �ĤH�쪱�a���e�������ʵe
        /// </summary>
        public void EnemyAniPos()
        {
            int range = traCharatorAheadRowPlace.Length;

            // �M�� = �}�C.�ର�M��();
            // listPlayerPlace = traCharatorAheadRowPlace.ToList();

            if(aheadEnemy.Length != 0 && range != 0)
            {
                aniEnemy.SetBool(parDamage,true);
            }
            else
            {
                aniEnemy.SetBool(parDamage, false);
            }
        }

        #endregion
    }
}
using System.Linq;                  // �d�߻y��
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class CharactorAheadRowPosition : MonoBehaviour
    {
        #region ���
        [Header("�ʧ@��l����e�@�Ʈy��"), SerializeField]
        private Transform[] traCharatorAheadRowPlace;

        [SerializeField]
        private List<Transform> listPlayerAheadPlace = new List<Transform>();

        #endregion


        #region �ƥ�
        void Update()
        {

        }
        #endregion

        #region ��k
        public void EnemyAniPos()
        {
            // �M�� = �}�C.�ର�M��();
            listPlayerAheadPlace = traCharatorAheadRowPlace.ToString;
        }
        #endregion
    }
}
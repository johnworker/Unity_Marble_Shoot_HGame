using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LEO
{
    /// <summary>
    /// �޲z�����G��s�����ƶq
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        /// <summary>
        /// �����ƶq
        /// </summary>
        private TextMeshProUGUI textCoin;

        /// <summary>
        /// �����`��
        /// </summary>
        private int totalCoin;
        private void Awake()
        {
            textCoin = GameObject.Find("�����Ʀr").GetComponent<TextMeshProUGUI>();
        }

        /// <summary>
        /// �K�[�@�Ӫ����ç�s����
        /// </summary>
        public void AddCoinAndUpdate()
        {
            totalCoin++;
            textCoin.text = totalCoin.ToString();
        }
    }

}

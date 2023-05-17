using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LEO
{
    public class LevelManager : MonoBehaviour
    {
        public Button[] difficultyButtons;

        private int selectedDifficulty;

        private void Start()
        {
            // Ū�����a�ҿ諸������
            selectedDifficulty = PlayerPrefs.GetInt("SelectedDifficulty", 0);

            // �]�m�����׫��s�����ʪ��A
            for (int i = 0; i < difficultyButtons.Length; i++)
            {
                if (i == selectedDifficulty)
                {
                    // ���a�ҿ諸������
                    difficultyButtons[i].interactable = false;
                }
                else
                {
                    // ��L�����׿ﶵ
                    difficultyButtons[i].interactable = true;
                }
            }
        }

        public void SetDifficulty(int difficultyIndex)
        {
            // ��s��ܪ�������
            selectedDifficulty = difficultyIndex;

            // �s�x��ܪ�������
            PlayerPrefs.SetInt("SelectedDifficulty", selectedDifficulty);

            // �]�m�����׫��s�����ʪ��A
            for (int i
    = 0; i < difficultyButtons.Length; i++)
            {
                if (i == selectedDifficulty)
                {
                    // ���a�ҿ諸������
                    difficultyButtons[i].interactable = false;
                }
                else
                {
                    // ��L�����׿ﶵ
                    difficultyButtons[i].interactable = true;
                }

                // �ھ������׳]�m���d�ѼƩΥ[�����������d
                switch (selectedDifficulty)
                {
                    case 0:
                        // ²������
                        // �]�m���d�ѼƩΥ[��²�����ת����d
                        break;
                    case 1:
                        // ��������
                        // �]�m���d�ѼƩΥ[���������ת����d
                        break;
                    case 2:
                        // �x������
                        // �]�m���d�ѼƩΥ[���x�����ת����d
                        break;
                }
            }
        }
    }
}

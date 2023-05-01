using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LEO {
 
    public class SystemDamage : MonoBehaviour
    {
        /// <summary>
        /// 傷害數字
        /// </summary>

        public float damage;

        [SerializeField, Header("大於 100 顏色")]
        private Color colorGratherThan100 = new Color(0.9f, 0.7f, 0.5f);
        [SerializeField, Header("大於 200 顏色")]
        private Color colorGratherThan200 = new Color(0.8f, 0.5f, 0.5f);

        private float limitUp;
        private float limitRight;
        private TextMeshProUGUI textDmage;

        // 快速選取同一個詞的方式 Alt + Shift + >
        [SerializeField, Header("效果間隔")]
        private float interval = 0.025f;

        private void Start()
        {
            textDmage = GetComponentInChildren<TextMeshProUGUI>();
            textDmage.text = damage.ToString();

            if (damage >= 200) textDmage.color = colorGratherThan200;
            else if (damage >= 100) textDmage.color = colorGratherThan100;

            limitUp = Random.Range(0.01f, 0.05f);

            int r = Random.Range(0, 2);
            if (r == 0) limitRight = -0.1f;
            else if (r == 1) limitRight = 0.1f;

            StartCoroutine(MovementUp());
            StartCoroutine(MovementRight());
            StartCoroutine(ScaleEffect());

        }

        private IEnumerator MovementUp()
        {
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }

            for (int i = 0; i < 3; i++)
            {
                transform.position -= transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }

            for (int i = 0; i < 10; i++)
            {
                textDmage.color -= new Color(0, 0, 0, 0.1f);
                yield return new WaitForSeconds(interval);
            }

        }

        private IEnumerator MovementRight()
        {
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.right * limitRight;
                yield return new WaitForSeconds(interval);
            }
        }

        private IEnumerator ScaleEffect()
        {
            for (int i = 0; i < 5; i++)
            {
                transform.localScale += Vector3.one * 0.0001f;
                yield return new WaitForSeconds(interval);
            }

            for (int i = 0; i < 5; i++)
            {
                transform.localScale -= Vector3.one * 0.0001f;
                yield return new WaitForSeconds(interval);
            }

        }

    }

}
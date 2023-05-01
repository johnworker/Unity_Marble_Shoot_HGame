using UnityEngine;

namespace LEO
{
    /// <summary>
    /// ���Ĩt�ΡG���Ѽ����n�����\��
    /// </summary>
    // �n�D����(����(����1)�A����(����2)�A...)
    // �M�Φ��}���ܹC������ɭԷ|����
    [RequireComponent(typeof(AudioSource))]
    public class SystemSound : MonoBehaviour
    {
        // static���N�䬰�@�}�l�x�s�b�O���餺

        // �p�G��L�t�λݭn�P�����q�i�H�ϥΦ��g�k
        // �w�q�@�ӻP���}���ۦP�����]���R�A
        // �W�ٲߺD�|�� instance ����
        public static SystemSound instance;

        private AudioSource aud;

        private void Awake()
        {
            // Awake �� Start �N���������}��
            instance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// ���񭵮�
        /// </summary>
        /// <param name="sound">������</param>
        /// <param name="rangeVolum">���q�d��</param>
        public void PlaySound(AudioClip sound, Vector2 rangeVolum)
        {
            // ���o�H���d�򪺭��q
            float volum = Random.Range(rangeVolum.x, rangeVolum.y);
            // ���Ĥ���,����@������(���ġA���q)
            aud.PlayOneShot(sound, volum);
        }
    }

}

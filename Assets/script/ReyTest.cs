using UnityEngine;
using System.Collections;

namespace LEO
{
    public class RayTest : MonoBehaviour
    {
        public Transform startPos;//�_�I��m
        public Transform finalPos;//���I��m
        void Update()
        {
            // (finalPos.position - startPos.position) ���I��m��h �_�I��m �����V�V�q
            Ray ray = new Ray(startPos.position, (finalPos.position - startPos.position));
            // ��X�˴�
            print(ray);
        }
    }
}
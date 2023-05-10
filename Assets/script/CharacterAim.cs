using UnityEngine;

namespace LEO
{
    public class CharacterAim : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 10f;
        [SerializeField] private float maxAngle = 60f;

        public float maxDistance = 100f;
        public LineRenderer lineRenderer;

        public Color lineColor = Color.red;
        public float lineWidth = 5f;
        private void Start()
        {
            // ��� LineRenderer �ե󪺤ޥ�
            lineRenderer = GetComponent<LineRenderer>();

            // �]�m�u�����C��M�e��
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
        }

        void Update()
        {
            
            // ������п�J
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");

            
            // �p��g�u��V
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            // �˴��g�u�O�_�I��
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // �p�⨤��
                Vector3 lookAtPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                Vector3 direction = lookAtPoint - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);

                // �����
                angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

                // ���ਤ��
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
            


            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
            }
            else
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, transform.position + transform.forward * maxDistance });
            }
        }
    }
}
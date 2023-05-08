using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class MarbleEffect : MonoBehaviour
    {
        public Transform marble;

        private void Update()
        {
            marble.Rotate(0, 1, 0);
        }
    }
}
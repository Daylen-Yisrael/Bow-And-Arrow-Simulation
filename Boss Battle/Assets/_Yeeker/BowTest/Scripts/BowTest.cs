using System;
using UnityEngine;

namespace _Yeeker.BowTest.Scripts
{
    public class BowTest : MonoBehaviour
    {
        public Transform _arrowHolder;
        public GameObject _arrow;

        bool _loaded;
        IArrow arrow;
        void Update()
        {
            ArrowInput();
        }

        void ArrowInput()
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                if (_loaded == false) 
                {
                    GameObject obj = Instantiate(_arrow, _arrowHolder.position, Quaternion.identity);
                    arrow = obj.GetComponent<IArrow>();
                    _loaded = true;
                }
            }

            if (Input.GetMouseButtonDown(2))
            {
                arrow.Fire();
                _loaded = false;
            }
        }
    }
}

using System;
using System.Collections;
using UnityEngine;

namespace _Yeeker.BowTest.Scripts
{
    public class BowTest : MonoBehaviour
    {
        public Transform _arrowHolder;
        public Transform _bowString;
        public Transform _fullyDrawn;
        
        public GameObject _arrow;
        public float _arrowForce = 10;
        public float _chargeTime = 60f;
        
        bool _loaded;
        IArrow arrow;
        GameObject obj;

        Vector3 stringStartPos;

        void Start()
        {
            stringStartPos = _bowString.position;
        }

        void Update()
        {
            ArrowInput();
        }

        void ArrowInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //StartCoroutine(DrawBackCoroutine());
            }   
            
            if(Input.GetKeyUp(KeyCode.R))
            {
               // StartCoroutine(StopDrawBackCoroutine());
            }

            if (Input.GetKeyDown(KeyCode.Q) && !_loaded)
            {

                obj = Instantiate(_arrow, _arrowHolder);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
                obj.transform.localScale = Vector3.one;
                _loaded = true;
                arrow = obj.GetComponent<IArrow>();
            }
            
            else if (Input.GetKeyDown(KeyCode.Q) && _loaded)
            {
                Destroy(obj);
                _loaded = false;
            }

            if (Input.GetMouseButtonDown(0) && _loaded)
            {
                arrow?.Fire(_arrowForce);
                arrow = null;
                _loaded = false;
            }
        }
        
        
    }
}

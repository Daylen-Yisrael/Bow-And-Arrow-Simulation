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
        public float _chargeTime = 0.5f;
        
        bool _isDrawing;
        bool _loaded;
        IArrow arrow;
        GameObject obj;
        float t;

        Vector3 stringStartPos;

        void Start()
        {
            t = 0;
            stringStartPos = _bowString.localPosition;
        }

        void Update()
        {
            BowInput();
            BowDrawBack();
        }

        void BowDrawBack()
        {
            if (_isDrawing)
            {
                t += Time.deltaTime;
                t = Mathf.Clamp(t, 0f, _chargeTime);
                
            }

            if (!_isDrawing)
            {
                t -= Time.deltaTime * 6f;
                t = Mathf.Clamp(t, 0f, _chargeTime);
            }

            _bowString.localPosition = Vector3.Lerp(stringStartPos, _fullyDrawn.localPosition, t/_chargeTime);
        }

        void BowInput()
        {
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
                _isDrawing = false;
            }

            if (Input.GetMouseButtonDown(0) && _loaded)
            {
                _isDrawing = true;
            }

            if (Input.GetMouseButtonUp(0) && _loaded)
            {
                _loaded = false;
                arrow?.Fire(_arrowForce);
                _isDrawing = false;
                arrow = null;
            }
        }
        
        
    }
}

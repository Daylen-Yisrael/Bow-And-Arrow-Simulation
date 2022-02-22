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

        public float _chargeTime = 0.5f;

        public Vector2 _minMaxArrowForce = new Vector2(5f, 30f);
        float _arrowForce;

        bool _isDrawing;
        bool _loaded;
        IArrow arrow;
        GameObject obj;
        float _t;

        Vector3 stringStartPos;

        void Start()
        {
            _t = 0;
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
                _t += Time.deltaTime;
                _t = Mathf.Clamp(_t, 0f, _chargeTime);

            }

            if (!_isDrawing)
            {
                _t -= Time.deltaTime * 6f;
                _t = Mathf.Clamp(_t, 0f, _chargeTime);
            }

            _bowString.localPosition = Vector3.Lerp(stringStartPos, _fullyDrawn.localPosition, _t / _chargeTime);
            _arrowForce = Remap(stringStartPos, _fullyDrawn.localPosition, _minMaxArrowForce.x, _minMaxArrowForce.y,
                _bowString.localPosition);
        }

        void BowInput()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Arrow Force is " + _arrowForce);
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

        float Remap(Vector3 iMin, Vector3 iMax, float oMin, float oMax, Vector3 v)
        {
            Vector3 t = VecInverseLerp(iMin, iMax, v);

            return Mathf.Lerp(oMin, oMax, t.magnitude);
        }

        Vector3 VecInverseLerp(Vector3 min, Vector3 max, Vector3 v)
        {
            if (min == max)
            {
                return Vector3.zero;
            }

            float x = Mathf.InverseLerp(min.x, max.x, v.x);
            float y = Mathf.InverseLerp(min.y, max.y, v.y);
            float z = Mathf.InverseLerp(min.z, max.z, v.z);

            Vector3 t = new Vector3(x, y, z);
            return t;
        }
    }
}

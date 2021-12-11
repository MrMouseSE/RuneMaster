using System.Collections;
using UnityEngine;

namespace GlobalMap.GlobalMapScripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _cameraAxeleration;
        [SerializeField] private Transform _cameraHolderTransform;
        [SerializeField] private Transform _cameraTransform;
        private Vector2 _previousMousePosition;
        private bool _isMovable;
        private Vector3[] _camZposition = new Vector3[2];
        [SerializeField] private float _camZoomValue;

        private Coroutine _cameraZoom;

        private void Awake()
        {
            var position = _cameraTransform.localPosition;
            _camZposition[0] = position;
            _camZposition[1] = position + (-_cameraTransform.forward * _camZoomValue);
        }

        private void OnMouseDown()
        {
            var mousePos = Input.mousePosition;
            _previousMousePosition = mousePos;
            _isMovable = true;
        }

        private void OnMouseUp()
        {
            _isMovable = false;
        }

        private void Update()
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                RestartCoroutine(Input.mouseScrollDelta.y>0?_camZposition[0]:_camZposition[1]);
            }
        
        
            if (!_isMovable) return;
            RestartCoroutine(_camZposition[1]);

            var position = _cameraHolderTransform.position;
            var camPos = position;
            var mousePos = Input.mousePosition;
            var axeleration = _cameraAxeleration * 1/(10-new Vector2(camPos.x, camPos.z).magnitude);
            camPos.x -= (mousePos.x - _previousMousePosition.x) * axeleration;
            camPos.x = Mathf.Lerp(camPos.x, 5, Mathf.Clamp01(camPos.x - 4.5f));
            camPos.x = Mathf.Lerp(camPos.x, -5, Mathf.Clamp01(-camPos.x - 4.5f));
            camPos.z -= (mousePos.y - _previousMousePosition.y) * axeleration;
            camPos.z = Mathf.Lerp(camPos.z, 3.5f, Mathf.Clamp01(camPos.z - 2.5f));
            camPos.z = Mathf.Lerp(camPos.z, -6.7f, Mathf.Clamp01(-camPos.z - 6.4f));
            _previousMousePosition = mousePos;

            position = Vector3.Lerp(position,camPos,Time.deltaTime*3);
            _cameraHolderTransform.position = position;
        }

        private void RestartCoroutine(Vector3 camMoveToPosition)
        {
            if(_cameraZoom!=null)StopCoroutine(_cameraZoom);
            _cameraZoom = StartCoroutine(CameraZoom(camMoveToPosition));
        }

        private IEnumerator CameraZoom(Vector3 camMoveToPosition)
        {
            while ((_cameraTransform.localPosition - camMoveToPosition).magnitude > 0.1f)
            {
                _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, camMoveToPosition, Time.deltaTime*3);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
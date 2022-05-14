using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMovementScript : MonoBehaviour
    {
        public float speed = 0.5F;
        
        private Vector3 _current;
        private readonly Vector3 _anker = Vector3.zero;
        private float _normalFOV = 65.0F;
        private float _zoomedFOV = 32.5F;

        private Camera _camera;
        private LevelController _levelController;
        private Vector3 _startingPos;

        

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _levelController = GetComponent<LevelController>();
            _camera.fieldOfView = _normalFOV;
            _startingPos = _camera.transform.position;
        }

        private void Update()
        {
            if (Time.timeScale > 0.0F) {
                //Zoom
                if (!Input.mouseScrollDelta.Equals(Vector2.zero))
                {
                    if (Input.mouseScrollDelta.y < 0)
                    {
                        _camera.fieldOfView = _normalFOV;
                    }

                    if (Input.mouseScrollDelta.y > 0)
                    {
                        _camera.fieldOfView = _zoomedFOV;
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    _current = Input.mousePosition;
                    return;
                }

                if (!Input.GetMouseButton(0)) return;
                Vector3 deltaInput = Input.mousePosition - _current;
                deltaInput.Normalize();

                Vector3 move = new Vector3(0, deltaInput.x * speed, 0);
                Transform transformCam;
                (transformCam = _camera.transform).RotateAround(_anker, move, speed);

                Vector3 newCamVector = transformCam.position * -1.0F;
                float degreeDeviation = Vector3.SignedAngle(-_startingPos, newCamVector, Vector3.up);
                if (degreeDeviation < -45.0F || degreeDeviation > 45.0F)
                {
                    if (!_levelController.IsPaused())
                    {
                        transformCam.RotateAround(_anker, -move, speed);
                    }
                }
            }
        }
    }
}
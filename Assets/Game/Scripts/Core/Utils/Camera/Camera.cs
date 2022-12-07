using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using CoreGame.Camera.State;
using CoreGame.Utils.Interface;

namespace CoreGame.Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private List<Transform> _points;
        private CameraMoveState _cameraMoveState;
        private IState _mainState;
        private Transform _currentTransform;

        private void Awake()
        {
            _cameraMoveState = new CameraMoveState(_target, transform);
            _mainState = _cameraMoveState;
            _currentTransform = _points[0];
        }

        private void FixedUpdate()
        {
            if (_mainState != null)
            {
                _mainState.UpdateState();
            }
        }

        public void Switch()
        {
            if (_currentTransform == _points[1])
            {
                _currentTransform = _points[0];
            }
            else
            {
                _currentTransform = _points[1];
            }
            ChangeState(new CameraSwitchState(transform, _currentTransform.position, _currentTransform.rotation));
        }

        public void ChangeState(IState state)
        {
            _mainState = state;
        }
    }
}

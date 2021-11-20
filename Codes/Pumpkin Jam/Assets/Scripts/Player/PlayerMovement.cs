using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpHeight = 3f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float groundDistance;
        [SerializeField] private LayerMask groundMask;

        private CharacterController _controller;
        private Vector3 _velocity;
        private Transform _groundChecker;
        private bool _isGrounded;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _groundChecker = transform.Find("GroundChecker");
        }

        private void Update()
        {
            HorizontalMovement();
            VerticalMovement();
        }

        private void VerticalMovement()
        {
            _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, groundMask);
            var jump = Input.GetKeyDown(KeyCode.Space);
            
            if (!_isGrounded) {
                _velocity.y += gravity * Time.deltaTime;
            }

            else {
                if (jump) {
                    _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    _isGrounded = false;
                }
                else if (_velocity.y < 0f) {
                    _velocity.y = -2f;
                }
            }
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void HorizontalMovement()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var playerTransform = transform;
            var move = playerTransform.right * x + playerTransform.forward * z;
            _controller.Move(move * (moveSpeed * Time.deltaTime));
        }
    }
}
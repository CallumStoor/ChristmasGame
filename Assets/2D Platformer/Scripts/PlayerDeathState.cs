using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerDeathState : MonoBehaviour
    {
        public float jumpForce;

        private Rigidbody2D _rigidbody;
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(new Vector2(1, 0.5f) * jumpForce, ForceMode2D.Impulse);
        }
    }
}


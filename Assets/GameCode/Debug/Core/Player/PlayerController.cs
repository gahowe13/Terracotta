using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugPlayer
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Config")]
        public Components components;
        public Properties properties;
        public States states;

        private PlayerInput input;

        public void Awake()
        {
            InputRead();
        }

        public void Update()
        {
            Movement();
            Example();
        }

        public void Example()
        {
            bool Interact = input.PlayerActions.Interact.triggered;

            if (Interact)
                GameEvents.current.CallExample();
        }

        public void Movement()
        {
            Vector2 moveVector = new Vector2(properties.movement.x, properties.movement.y);
            if (moveVector != Vector2.zero)
            {
                states.IsMoving = true;

                components.PlayerAnim.SetFloat(AnimatorID.Horizontal, moveVector.x);
                components.PlayerAnim.SetFloat(AnimatorID.Vertical, moveVector.y);

                components.PlayerRB.velocity = moveVector * 5;
                GameEvents.current.Moving();
            }
            else
            {
                states.IsMoving = false;
                components.PlayerRB.velocity = Vector2.zero;
            }

            components.PlayerAnim.SetBool(AnimatorID.IsMoving, states.IsMoving);
        }

        public void InputRead()
        {
            input = new PlayerInput();
            input.PlayerActions.Movement.performed += ctx => properties.movement = ctx.ReadValue<Vector2>();
            input.PlayerActions.Rotation.performed += ctx => properties.rotation = ctx.ReadValue<Vector2>();
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "TableExample")
            {
                
            }
        }

        #region Input Hide
        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }
        #endregion
    }

    [System.Serializable]
    public class Components
    {
        [Header("Player")]
        public Animator PlayerAnim;
        public Rigidbody2D PlayerRB;
    }

    [System.Serializable]
    public class Properties
    {
        [Header("Player")]
        public float Speed = 5;

        [HideInInspector]
        public Vector2 movement;
        [HideInInspector]
        public Vector2 rotation;
    }

    [System.Serializable]
    public class States
    {
        [Header("Player")]
        public bool IsMoving;
    }

    public static class AnimatorID
    {
        public static readonly int Horizontal = Animator.StringToHash("Horizontal");
        public static readonly int Vertical = Animator.StringToHash("Vertical");
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
    }
}
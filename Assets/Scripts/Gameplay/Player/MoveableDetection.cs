﻿using System;
using Comma.Gameplay.DetectableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Comma.Gameplay.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class MoveableDetection : MonoBehaviour
    {
        private bool isHoldingObject = false; 
        [SerializeField] private LayerMask _layerMask; 
        [SerializeField] private float _distance,_radius;

        private void Update()
        {
            OnHitMoveable();
        }

        private void OnHitMoveable()
        {
            var rightDirection = new Vector2(transform.position.x + _distance, transform.position.y);
            var leftDirection = new Vector2(transform.position.x - _distance, transform.position.y);
            RaycastHit2D rightHit = Physics2D.CircleCast(rightDirection, _radius, rightDirection,0,_layerMask);
            RaycastHit2D leftHit = Physics2D.CircleCast(leftDirection, _radius, leftDirection,0,_layerMask);
            
            if(rightHit.collider != null && rightHit.collider.CompareTag("Moveable"))
            {
                GetInput(rightHit.collider);
                Debug.Log("Right hand detection Moveable "+rightHit.collider.gameObject.name);
            }
            else if(leftHit.collider != null && leftHit.collider.CompareTag("Moveable"))
            {
                GetInput(leftHit.collider);
                Debug.Log("Left hand detection Moveable "+leftHit.collider.gameObject.name);
            }
        }
        private void GetInput(Collider2D col)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isHoldingObject)
                {
                    isHoldingObject = false;
                    var moveable = col.GetComponent<MoveableObject>();
                    moveable.UnInteract();
                }
                else
                {
                    isHoldingObject = true;
                    IDetectable detectable = col.gameObject.GetComponent<IDetectable>();
                    detectable?.Interact();
                }
            }
        }

        private void OnDrawGizmos()
        {
            var rightDirection = new Vector2(transform.position.x + _distance, transform.position.y);
            var leftDirection = new Vector2(transform.position.x - _distance, transform.position.y);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(rightDirection, _radius);
            Gizmos.DrawWireSphere(leftDirection,_radius);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Moveable"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isHoldingObject)
                    {
                        isHoldingObject = false;
                    }
                    else
                    {
                        IDetectable coll = collision.gameObject.GetComponent<IDetectable>();
                        coll?.Interact();
                    }
            
                }
            }
        }
    }
}
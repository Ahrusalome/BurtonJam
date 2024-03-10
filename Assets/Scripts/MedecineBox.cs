using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class MedecineBox : MonoBehaviour, IInteractable
    {
        public bool IsOpen = false;
        [SerializeField] private float Speed = 1f;

        [Header("Rotation Configs")] [SerializeField]
        private float RotationAmount = 90f;

        [SerializeField] private float ForwardDirection = 0;
        [SerializeField] private Transform PlayerTransform;

        private Vector3 StartRotation;
        private Vector3 Forward;

        private Coroutine AnimationCoroutine;

        public void Interract()
        {
            Open(PlayerTransform.position);
        }
        private void Awake()
        {
            StartRotation = transform.rotation.eulerAngles;
            // Since "Forward" actually is pointing into the door frame, choose a direction to think about as "forward" 
            Forward = transform.right;
        }
        public void Open(Vector3 UserPosition)
        {
            if (IsOpen)
                return;
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            float dot = Vector3.Dot(Forward, (UserPosition - transform.position).normalized);
            AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
        }

        private IEnumerator DoRotationOpen(float ForwardAmount)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation;

            if (ForwardAmount >= ForwardDirection)
            {
                endRotation = Quaternion.Euler(new Vector3(StartRotation.x + RotationAmount, 0, 0));
            }
            else
            {
                endRotation = Quaternion.Euler(new Vector3(StartRotation.x - RotationAmount, 0, 0));
            }

            IsOpen = true;

            float time = 0;
            while (time < 1)
            {
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class MedecineBox : MonoBehaviour
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
        
        private void Awake()
        {
            StartRotation = transform.rotation.eulerAngles;
            Forward = transform.right;
        }
        
        
        public void Open()
        {
            if (IsOpen)
                return;
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            
            AnimationCoroutine = StartCoroutine(DoRotationOpen());
        }

        private IEnumerator DoRotationOpen()
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation;


            endRotation = Quaternion.Euler(new Vector3(StartRotation.x - RotationAmount, 0, 0));

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
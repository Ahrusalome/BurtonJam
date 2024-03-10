using UnityEngine;

namespace DefaultNamespace
{
    public class PhoneInterract : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject phoneCanvas;
        public void Interract()
        {
            GetComponent<BoxCollider>().enabled = false;
            phoneCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
using UnityEngine;

namespace DefaultNamespace
{
    public class Pills : MonoBehaviour, IInteractable
    {
        public void Interract()
        {
            GameManager._manager.spiderIsBig = false;
            Destroy(gameObject);
        }
    }
}
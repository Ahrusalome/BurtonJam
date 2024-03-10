using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
    [SerializeField] private TMP_Text pickUpText;
    public void Interract()
    {
        GameManager._manager.pickedUpObj = this.gameObject;
        StartCoroutine("PickUpPopup", this.name);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public IEnumerator PickUpPopup(string name)
    {
        pickUpText.text = $"+ {name}";
        pickUpText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        pickUpText.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
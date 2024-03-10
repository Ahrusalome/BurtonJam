using System.Collections;
using UnityEngine;

public class Spider : MonoBehaviour
{
    /*--------------------------------------------------
    |                     FIELDS                       | 
    --------------------------------------------------*/

    [Header("Parameters")]
    private float _time = 0f;
    public float changeMultiplier = 2f;
    public float timeMultiplier = 0.5f;

    [SerializeField] private float changeSpeed;
    private Vector3 scale;
    /*--------------------------------------------------
    |                    METHODS                       |
    --------------------------------------------------*/
    void Start()
    {
        scale = transform.localScale;
        StartCoroutine(ChangeScale());
    }

    public IEnumerator ChangeScale() {
        for(float elapsedTime = 0; elapsedTime <= 1; elapsedTime += Time.unscaledDeltaTime*changeSpeed)
        {
            if (changeMultiplier < 1f) {
                if (transform.localScale.x < scale.x * changeMultiplier)
                    break;
                float newScale = Mathf.Lerp(transform.localScale.x, scale.x * changeMultiplier, elapsedTime);
                yield return transform.localScale = new Vector3(newScale, newScale, newScale);
                
            } else {
                if (transform.localScale.x > scale.x * changeMultiplier)
                    break;
                float newScale = Mathf.Lerp(transform.localScale.x, scale.x * changeMultiplier, elapsedTime);
                yield return transform.localScale = new Vector3(newScale, newScale, newScale);
            }
        }
    }
}

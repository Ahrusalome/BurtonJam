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

    /*--------------------------------------------------
    |                    METHODS                       |
    --------------------------------------------------*/
    void Start() {
        StartCoroutine(ChangeScale(transform.localScale));
    }

    IEnumerator ChangeScale(Vector3 scale) {
        for(;;)
        {
            if (changeMultiplier < 1f) {
                if (transform.localScale.x > scale.x * changeMultiplier) {
                    float newScale = Mathf.Lerp(scale.x, scale.x * changeMultiplier, _time);
                    _time += timeMultiplier * Time.deltaTime;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                } else {
                    break;
                }
            } else {
                if (transform.localScale.x < scale.x * changeMultiplier) {
                    float newScale = Mathf.Lerp(scale.x, scale.x * changeMultiplier, _time);
                    _time += timeMultiplier * Time.deltaTime;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                } else {
                    break;
                }
            }
            
            yield return null;
        }
    }
}

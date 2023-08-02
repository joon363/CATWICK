using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class InteractableObject : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public float SCALE_FACTOR;
    public float SMOOTH_TIME;
    private Vector3 UNIT_V = new Vector3(1, 1, 1);
    // Use this for initialization

    // Update is called once per frame

    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;
    public UnityEvent ClickEvent;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Enter: {this.gameObject.name}");
        EnterEvent.Invoke();
        StopAllCoroutines();
        StartCoroutine(Zoom(UNIT_V, UNIT_V * SCALE_FACTOR, SMOOTH_TIME));
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Exit: {this.gameObject.name}");
        ExitEvent.Invoke();
        StartCoroutine(Zoom(UNIT_V * SCALE_FACTOR, UNIT_V, SMOOTH_TIME  ));
    }
    private IEnumerator Zoom(Vector3 current, Vector3 target, float time)
    {
        Vector3 velocity = Vector3.zero;

        //this.transform.localScale = current;
        float offset = 0.01f;
        while (Mathf.Abs(target.x- this.transform.localScale.x) > offset)
        {
            this.transform.localScale
                = Vector3.SmoothDamp(this.transform.localScale, target, ref velocity, time);
            yield return null;
        }

        transform.localScale = target;
        yield return null;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Click: {this.gameObject.name}");
        ClickEvent.Invoke();
    }

}
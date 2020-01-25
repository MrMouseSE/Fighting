using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AIVisualSignalSystem : MonoBehaviour
{
    public GameObject AttackSignal;

    private RectTransform _signalTransform;
    private Image _image;
    private Color _startColor;
    private Vector3 _startPosition;

    private void Start()
    {
        _image = AttackSignal.GetComponent<Image>();
        _signalTransform = AttackSignal.GetComponent<RectTransform>();
        _startColor = _image.color;
        _startPosition = _signalTransform.transform.position;
        
    }

    public void PlaceAttackSignal(int actionIndex)
    {
        if (actionIndex>4)
        {
            _image.color = Color.blue;
            switch (actionIndex)
            {
                case 5:
                    _signalTransform.transform.localPosition = new Vector3(30, 100, -1);
                    break;
                case 6:
                    _signalTransform.transform.localPosition = new Vector3(-30, 100, -1);
                    break;
            }
        }
        else
        {
            switch (actionIndex)
            {
                    case 1:
                        _signalTransform.transform.localPosition = new Vector3(250,130,-1);
                        break;
                    case 2:
                        _signalTransform.transform.localPosition = new Vector3(-250,130,-1);
                        break;
                    case 3:
                        _signalTransform.transform.localPosition = new Vector3(250,-130,-1);
                        break;
                    case 4:
                        _signalTransform.transform.localPosition = new Vector3(-250,-130,-1);
                        break;
            }
        }

        var imageColor = _image.color;
        imageColor.a = 1f;
        _image.color = imageColor;
        StartCoroutine(DelayBeforeReset(0.5f));
    }

    private IEnumerator DelayBeforeReset(float time)
    {
        var imageColor = _image.color;
        imageColor.a -= 0.2f;
        _image.color = imageColor;
        yield return new WaitForSeconds(time);
        ResetImageToDefault();
    }

    private void ResetImageToDefault()
    {
        _signalTransform.transform.localPosition = _startPosition;
        _image.color = _startColor;
    }
}
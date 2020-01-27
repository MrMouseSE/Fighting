using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AIVisualSignalSystem : MonoBehaviour
{
    public RectTransform SignalTransform;
    public Image Image;
    private Color _startColor;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startColor = Image.color;
        _startPosition = SignalTransform.transform.position;
    }

    public void PlaceAttackSignal(int actionIndex)
    {
        if (actionIndex>4)
        {
            Image.color = Color.blue;
            switch (actionIndex)
            {
                case 5:
                    SignalTransform.transform.localPosition = new Vector3(30, 100, 49);
                    break;
                case 6:
                    SignalTransform.transform.localPosition = new Vector3(-30, 100, 49);
                    break;
            }
        }
        else
        {
            Image.color = Color.red;
            switch (actionIndex)
            {
                    case 1:
                        SignalTransform.transform.localPosition = new Vector3(250,130,49);
                        break;
                    case 2:
                        SignalTransform.transform.localPosition = new Vector3(-250,130,49);
                        break;
                    case 3:
                        SignalTransform.transform.localPosition = new Vector3(250,-130,49);
                        break;
                    case 4:
                        SignalTransform.transform.localPosition = new Vector3(-250,-130,49);
                        break;
            }
        }

        var imageColor = Image.color;
        imageColor.a = 1f;
        Image.color = imageColor;
        StartCoroutine(DelayBeforeReset(0.5f));
    }

    private IEnumerator DelayBeforeReset(float time)
    {
        var imageColor = Image.color;
        imageColor.a -= 0.2f;
        Image.color = imageColor;
        yield return new WaitForSeconds(time);
        ResetImageToDefault();
    }

    private void ResetImageToDefault()
    {
        SignalTransform.transform.localPosition = new Vector3(0,0,49);
        Image.color = _startColor;
    }
}
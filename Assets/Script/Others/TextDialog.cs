using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialog : MonoBehaviour
{
    public static TextDialog _ins;

    [SerializeField]
    public string content;
    string contentShown = "";
    int currentIndex = 0;

    /// <summary>
    /// Characters per Second
    /// </summary>
    [SerializeField]
    float speed;
    float countTime;

    [SerializeField]
    float liveTime;
    float countLiveTime;

    [SerializeField]
    Text text;

    [SerializeField]
    GameObject theWholeThing;
    [SerializeField]
    RectTransform image;
    [SerializeField]
    AnimationCurve imgCurve;
    [SerializeField]
    float imageAnimationSpeed;
    public float delayPopup;
    float countDelay;
    float countImgTime;

    bool started = false;
    bool textStart = false;
    bool close = false;

    // Start is called before the first frame update
    void Start()
    {
        theWholeThing.SetActive(false);
        text.text = contentShown;
        countTime = 0;
        _ins = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDelay < delayPopup)
        {
            countDelay += Time.deltaTime;
            return;
        }
        if(started && !textStart)
        {
            UpdateShowImage();
        }
        if(textStart)
        {
            UpdateText();
        }

        if(contentShown == content && !close)
        {
            countLiveTime += Time.deltaTime;
            if (countLiveTime > liveTime)
            {
                started = false;
                close = true;
                countImgTime = 0;
            }
        }

        if(close)
        {
            UpdateCloseImage();
        }
    }

    private void UpdateShowImage()
    {
        if(started && !textStart)
        {
            float y_size = imgCurve.Evaluate(countImgTime * imageAnimationSpeed);
            y_size = Mathf.Clamp(y_size, 0, 1);

            var scale = image.transform.localScale;
            scale.y = y_size;

            image.transform.localScale = scale;

            if(y_size == 1)
            {
                textStart = true;
            }

            countImgTime += Time.deltaTime;
        }
    }

    private void UpdateCloseImage()
    {
        float y_size = imgCurve.Evaluate((1 - countImgTime) * imageAnimationSpeed);
        y_size = Mathf.Clamp(y_size, 0, 1);

        var scale = image.transform.localScale;
        scale.y = y_size;

        image.transform.localScale = scale;

        if (y_size == 0)
        {
            theWholeThing.SetActive(false);
        }

        countImgTime += Time.deltaTime;
    }

    private void UpdateText()
    {
        int numberOfChar = (int)(countTime * speed);
        currentIndex += numberOfChar;
        currentIndex = Mathf.Clamp(currentIndex, 0, content.Length);

        contentShown = content.Substring(0, currentIndex);

        text.text = contentShown;

        countTime %= (1.0f / speed);
        countTime += Time.deltaTime;
    }

    public void Show()
    {
        started = true;
        textStart = false;

        contentShown = "";
        text.text = contentShown;
        countTime = 0;
        currentIndex = 0;
        countImgTime = 0;
        close = false;

        countDelay = 0;

        theWholeThing.SetActive(true);
    }
}

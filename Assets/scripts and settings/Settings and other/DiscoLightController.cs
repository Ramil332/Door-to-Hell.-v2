// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class DiscoLightController : MonoBehaviour
{
    public string discoTag = "Disco";
    public float colorChangeSpeed = 1.0f;

    private Light discoLight;
    private Color currentColor;
    private Color targetColor;

    void Start()
    {
        GameObject[] discoObjects = GameObject.FindGameObjectsWithTag(discoTag);
        if (discoObjects.Length > 0)
        {
            discoLight = discoObjects[0].GetComponent<Light>();
            currentColor = discoLight.color;
            targetColor = GetRandomColor();
        }
        else
        {
            Debug.LogError("Объект с тегом 'Disco' не найден.");
        }
    }

    void Update()
    {
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * colorChangeSpeed);
        discoLight.color = currentColor;

        if (Vector4.Distance(currentColor, targetColor) < 0.1f)
        {
            targetColor = GetRandomColor();
        }
    }
    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}

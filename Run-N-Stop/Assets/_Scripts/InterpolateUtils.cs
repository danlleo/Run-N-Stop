using UnityEngine;

public static class InterpolateUtils 
{
    // This formula produces an interpolation that starts and ends slowly, with a faster motion in the middle.
    public static float EaseInOut(float t) => t < 0.5f ? 2f * t * t : 1f - Mathf.Pow(-2f * t + 2f, 2f) / 2f;

    // This formula combines the ease-out and ease-in effects, resulting in a slower motion at the start and end, with a faster motion in the middle.
    public static float EaseOutIn(float t) => t < 0.5f ? (1f - Mathf.Pow(1f - 2f * t, 2f)) / 2f : (Mathf.Pow(2f * t - 1f, 2f) + 1f);

    // This formula creates an interpolation that starts fast and slows down towards the end.
    public static float EaseIn(float t) => t * t;

    // This formula creates an interpolation that starts fast and slows down towards the end.
    public static float EaseOut(float t) => 1f - Mathf.Pow(1f - t, 2f);

    // This formula provides an exponential easing effect, where the interpolation starts slow and accelerates towards the end.
    public static float EaseExponential(float t) => Mathf.Pow(t, 2f);

    // This formula creates a bouncing effect, simulating an elastic behavior. It starts with a slight overshoot and settles into the final value.
    public static float ElasticIn(float t)
    {
        float c4 = (2 * Mathf.PI) / 3;

        return t == 0 ? 0 : t == 1 ? 1 : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
    }

    // This formula creates a smooth elastic motion that starts quickly and slows down as it approaches the end.
    public static float ElasticOut(float t)
    {
        const float AMPLITUDE = 1f;
        const float PERIOD = 0.3f;

        if (t <= 0f || t >= 1f)
            return t;

        float s = PERIOD / (2 * Mathf.PI) * Mathf.Asin(1f / AMPLITUDE);

        return (AMPLITUDE * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / PERIOD) + 1f);
    }
}

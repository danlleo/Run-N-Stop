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

    // This formula starts and ends slowly with an accelerated middle section.
    public static float EaseInOutCubic(float t) => t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f);

    // This formula starts slowly and then rapidly gains speed as the input value increases.
    public static float EaseInCubic(float t) => t * t * t;

    // This formulate starts with a higher speed and gradually slows down as the input value approaches 1
    public static float EaseOutCubic(float t)
    {
        float f = t - 1f;

        return f * f * f + 1f;
    }

    // This formula starts and ends slowly with an accelerated middle section.
    public static float EaseInOutQuart(float t) => t < 0.5f ? 8f * t * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 4f) / 2f;

    // This formula starts slowly and gradually accelerates.
    public static float EaseInQuart(float t) => t * t * t * t;

    // This formula starts quickly and gradually decelerates.
    public static float EaseOutQuart(float t) => 1f - Mathf.Pow(1f - t, 4);

    // This formula starts slowly and exponentially accelerates.
    public static float EaseInExponential(float t) => Mathf.Pow(2f, 10f * (t - 1f));

    // This formula starts quickly and exponentially decelerates.
    public static float EaseOutExponential(float t) => 1f - Mathf.Pow(2f, -10f * t);

    // This formula uses a combination of exponential and trigonometric functions to create the elastic effect. It starts slowly, accelerates, and then decelerates with a bouncing motion.
    public static float ElasticInOut(float t, float amplitude, float period)
    {

        float s = period / 4;
        float s2 = s * 2;

        if (amplitude < 1)
        {
            amplitude = 1;
            s = period / 4;
        }
        else
        {
            s = period / (2 * Mathf.PI) * Mathf.Asin(1 / amplitude);
        }

        if (t < 0.5f)
        {
            t = t * 2;

            return -0.5f * (amplitude * Mathf.Pow(2, 10 * (t -= 1)) * Mathf.Sin((t - s) * s2 * Mathf.PI / period));
        }
        else
        {
            t = t * 2 - 1;

            return amplitude * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * s2 * Mathf.PI / period) * 0.5f + 1f;
        }
    }

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

        float s = PERIOD / (2 * Mathf.PI) * Mathf.Asin(1f / AMPLITUDE);

        return (AMPLITUDE * Mathf.Pow(2f, -10f * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / PERIOD) + 1f);
    }
}

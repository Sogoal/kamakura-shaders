using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemRampGenerator : MonoBehaviour {

    public Gradient procedrualGradientRamp;
    public bool procedrualGradientEnabled = false;
    public bool updateEveryFrame = false;

    private ParticleSystemRenderer psr;
    private Texture2D rampTexture;

	void Start () {
        psr = GetComponent<ParticleSystemRenderer>();

        if (procedrualGradientEnabled == true)
        {
            UpdateRampTexture();
        }
    }

    void Update () {
        if (procedrualGradientEnabled == true)
        {
            if (updateEveryFrame == true)
            {
                UpdateRampTexture();
            }
        }
    }

    // Generating a texture from gradient variable
    Texture2D GenerateTextureFromGradient(Gradient grad)
    {
        float width = 256;
        float height = 1;
        Texture2D text = new Texture2D((int)width, (int)height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color col = grad.Evaluate(0 + (x / width));
                text.SetPixel(x, y, col);
            }
        }
        text.wrapMode = TextureWrapMode.Clamp;
        text.Apply();
        return text;
    }

    // Update procedural ramp textures and applying them to the shaders
    public void UpdateRampTexture()
    {
        rampTexture = GenerateTextureFromGradient(procedrualGradientRamp);
        psr.material.SetTexture("_Ramp", rampTexture);
    }
}

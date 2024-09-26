using UnityEngine;

public class DemonstrateLightRenderLayerBug : MonoBehaviour
{
    [SerializeField] private Light m_Light;

    private bool toggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle = !toggle;

            Debug.Log($"Light mask was: {m_Light.renderingLayerMask}");
            if (toggle)
            {
                m_Light.renderingLayerMask = 1 << (int)RenderLayer.RL0;
            }
            else
            {
                m_Light.renderingLayerMask = 1 << (int)RenderLayer.RL1;
            }

            Debug.Log($"Light mask became: {m_Light.renderingLayerMask}");
        }
    }

    // RenderLayer is just a way to map the ints setup in Project Settings > Graphics > URP Global Settings > Rendering Layers (3D) 
    // 0 maps to RL0
    // 1 maps to RL1 
    enum RenderLayer
    {
        RL0 = 0,
        RL1 = 1,
    }
}
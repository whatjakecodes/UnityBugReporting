using UnityEngine;

public class DemonstrateLightRenderLayerBug : MonoBehaviour
{
    [SerializeField] private Light m_Light;
    [SerializeField] private MeshRenderer m_Cube1;
    [SerializeField] private MeshRenderer m_Cube2;

    private bool _toggleLightLayers;
    private bool _toggleCubeLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLightLayers();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log($"Disabled Light component.");
            m_Light.enabled = false;

            ToggleLightLayers();

            Debug.Log($"Enabling Light component.");
            m_Light.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ToggleLightLayers();

            Debug.Log($"Disabled Light component.");
            m_Light.enabled = false;
            Debug.Log($"Enabling Light component.");
            m_Light.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"Disabled Light gameObject.");
            m_Light.gameObject.SetActive(false);

            ToggleLightLayers();

            Debug.Log($"Enabling Light gameObject.");
            m_Light.gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleLightLayers();

            Debug.Log($"Disabled Light gameObject.");
            m_Light.gameObject.SetActive(false);
            Debug.Log($"Enabling Light gameObject.");
            m_Light.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleCubeLayers();
        }
    }

    private void ToggleLightLayers()
    {
        _toggleLightLayers = !_toggleLightLayers;
        Debug.Log($"Light mask was: {m_Light.renderingLayerMask}");
        if (_toggleLightLayers)
        {
            m_Light.renderingLayerMask = 1 << (int)RenderLayer.RL0;
        }
        else
        {
            m_Light.renderingLayerMask = 1 << (int)RenderLayer.RL1;
        }

        Debug.Log($"Light mask became: {m_Light.renderingLayerMask}");
    }

    private void ToggleCubeLayers()
    {
        Debug.Log($"Cube1 mask was: {m_Cube1.renderingLayerMask}");
        Debug.Log($"Cube2 mask was: {m_Cube2.renderingLayerMask}");
        _toggleCubeLayers = !_toggleCubeLayers;

        if (_toggleCubeLayers)
        {
            m_Cube1.renderingLayerMask = 1 << (int)RenderLayer.RL1;
            m_Cube2.renderingLayerMask = 1 << (int)RenderLayer.RL0;
        }
        else
        {
            m_Cube1.renderingLayerMask = 1 << (int)RenderLayer.RL0;
            m_Cube2.renderingLayerMask = 1 << (int)RenderLayer.RL1;
        }

        Debug.Log($"Cube1 mask became: {m_Cube1.renderingLayerMask}");
        Debug.Log($"Cube2 mask became: {m_Cube2.renderingLayerMask}");
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
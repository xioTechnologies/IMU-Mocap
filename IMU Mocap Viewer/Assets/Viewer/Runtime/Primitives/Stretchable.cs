using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    [ExecuteAlways]
    public class Stretchable : MonoBehaviour
    {
        // private static readonly int ThicknessProperty = Shader.PropertyToID("_Thickness");
        // private static readonly int NearColorProperty = Shader.PropertyToID("_NearColor");
        // private static readonly int FarColorProperty = Shader.PropertyToID("_FarColor");
        // private static readonly int PixelScaleFactorProperty = Shader.PropertyToID("_PixelScaleFactor");
        // private static readonly int StencilValueProperty = Shader.PropertyToID("_StencilValue");

        [SerializeField] protected Material material;

        [SerializeField, Range(0f, 50f)] protected float lineWidthInPixels = 1f;

        [SerializeField] protected Color nearColor = Color.white;

        [SerializeField] protected Color farColor = Color.gray;

        [SerializeField] protected DrawType drawType = DrawType.Opaque;
        [SerializeField, Range(0, 255)] protected int order = 1;
        [SerializeField] protected StencilMode stencilMode = StencilMode.Stencil;

        private Material materialInstance;
        private MeshRenderer meshRenderer;
        private bool isDirty;

        public float LineWidthInPixels
        {
            get => lineWidthInPixels;
            set
            {
                if (Mathf.Approximately(lineWidthInPixels, value)) return;
                lineWidthInPixels = value;
                isDirty = true;
            }
        }

        public Color NearColor
        {
            get => nearColor;
            set
            {
                if (nearColor == value) return;
                nearColor = value;
                isDirty = true;
            }
        }

        public Color FarColor
        {
            get => farColor;
            set
            {
                if (farColor == value) return;
                farColor = value;
                isDirty = true;
            }
        }

        private void OnEnable() => Reset();

        private void OnValidate()
        {
            if (!enabled) return;

            Reset();
        }

        private void Reset()
        {
            Initialize();
            UpdateTransform();
            UpdateMaterialProperties();
        }

        private void Update()
        {
            if (!enabled) return;

            // In editor, we need to check for material changes
            if (Application.isPlaying == false && (materialInstance == null || materialInstance.shader != material.shader))
            {
                Initialize();
            }

            // materialInstance.SetFloat(PixelScaleFactorProperty, PixelScaleUtility.PixelScaleFactor);

            if (isDirty == false) return;

            UpdateMaterialProperties();

            isDirty = false;
        }

        private void OnDestroy()
        {
            if (materialInstance == null) return;

            if (Application.isPlaying)
            {
                Destroy(materialInstance);
            }
            else
            {
                DestroyImmediate(materialInstance);
            }

            materialInstance = null;
        }

        private void Initialize()
        {
            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }

            if (material == null)
            {
                // Debug.LogError($"Material not assigned on {gameObject.name}", gameObject);
                return;
            }

            if (materialInstance != null && materialInstance.shader == material.shader)
            {
                return;
            }

            if (materialInstance != null)
            {
                if (Application.isPlaying) Destroy(materialInstance);
                else DestroyImmediate(materialInstance);
            }

            materialInstance = new Material(material);
            meshRenderer.sharedMaterial = materialInstance;
        }

        private void UpdateMaterialProperties()
        {
            if (materialInstance == null) return;

            materialInstance.SetFloat(StretchableMaterial.ThicknessProperty, lineWidthInPixels);
            materialInstance.SetColor(StretchableMaterial.NearColorProperty, GetNearColor());
            materialInstance.SetColor(StretchableMaterial.FarColorProperty, GetFarColor());

            materialInstance.SetRenderOrder(drawType, order);
            materialInstance.SetBlendMode(drawType);
            materialInstance.ConfigureStencil(stencilMode, order);

            UpdateProperties(materialInstance);
        }

        protected virtual void UpdateProperties(Material materialInstance) { }

        protected virtual Color GetFarColor() => farColor;

        protected virtual Color GetNearColor() => nearColor;

        protected virtual void UpdateTransform() { }

        protected void SetDirty() => isDirty = true;
    }
}
Shader "Hidden/lilToonMultiGem"
{
    Properties
    {
        //----------------------------------------------------------------------------------------------------------------------
        // Base
        [lilToggle]     _Invisible                  ("Invisible", Int) = 0
                        _AsUnlit                    ("As Unlit", Range(0, 1)) = 0
                        _Cutoff                     ("Alpha Cutoff", Range(-0.001,1.001)) = 0.5
                        _SubpassCutoff              ("Subpass Alpha Cutoff", Range(0,1)) = 0.5
        [lilToggle]     _FlipNormal                 ("Flip Backface Normal", Int) = 0
        [lilToggle]     _ShiftBackfaceUV            ("Shift Backface UV", Int) = 0
                        _BackfaceForceShadow        ("Backface Force Shadow", Range(0,1)) = 0
        [lilHDR]        _BackfaceColor              ("Color", Color) = (0,0,0,0)
                        _VertexLightStrength        ("Vertex Light Strength", Range(0,1)) = 0
                        _LightMinLimit              ("Light Min Limit", Range(0,1)) = 0.05
                        _LightMaxLimit              ("Light Max Limit", Range(0,10)) = 1
                        _BeforeExposureLimit        ("Before Exposure Limit", Float) = 10000
                        _MonochromeLighting         ("Monochrome lighting", Range(0,1)) = 0
                        _AlphaBoostFA               ("Alpha Boost", Range(1,100)) = 10
                        _lilDirectionalLightStrength ("Directional Light Strength", Range(0,1)) = 1
        [lilVec3B]      _LightDirectionOverride     ("Light Direction Override", Vector) = (0.001,0.002,0.001,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Main
        [lilHDR] [MainColor] _Color                 ("Color", Color) = (1,1,1,1)
        [MainTexture]   _MainTex                    ("Texture", 2D) = "white" {}
        [lilUVAnim]     _MainTex_ScrollRotate       ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilHSVG]       _MainTexHSVG                ("Hue|Saturation|Value|Gamma", Vector) = (0,1,1,1)
                        _MainGradationStrength      ("Gradation Strength", Range(0, 1)) = 0
        [NoScaleOffset] _MainGradationTex           ("Gradation Map", 2D) = "white" {}
        [NoScaleOffset] _MainColorAdjustMask        ("Adjust Mask", 2D) = "white" {}

        //----------------------------------------------------------------------------------------------------------------------
        // Main2nd
        [lilToggleLeft] _UseMain2ndTex              ("Use Main 2nd", Int) = 0
        [lilHDR]        _Color2nd                   ("Color", Color) = (1,1,1,1)
                        _Main2ndTex                 ("Texture", 2D) = "white" {}
        [lilEnum]       _Main2ndTex_UVMode          ("UV Mode|UV0|UV1|UV2|UV3|MatCap", Int) = 0
        [lilEnum]       _Main2ndTex_Cull            ("Cull Mode|Off|Front|Back", Int) = 0
        [lilAngle]      _Main2ndTexAngle            ("Angle", Float) = 0
        [lilDecalAnim]  _Main2ndTexDecalAnimation   ("Animation|X Size|Y Size|Frames|FPS", Vector) = (1,1,1,30)
        [lilDecalSub]   _Main2ndTexDecalSubParam    ("Ratio X|Ratio Y|Fix Border", Vector) = (1,1,0,1)
        [lilToggle]     _Main2ndTexIsDecal          ("As Decal", Int) = 0
        [lilToggle]     _Main2ndTexIsLeftOnly       ("Left Only", Int) = 0
        [lilToggle]     _Main2ndTexIsRightOnly      ("Right Only", Int) = 0
        [lilToggle]     _Main2ndTexShouldCopy       ("Copy", Int) = 0
        [lilToggle]     _Main2ndTexShouldFlipMirror ("Flip Mirror", Int) = 0
        [lilToggle]     _Main2ndTexShouldFlipCopy   ("Flip Copy", Int) = 0
        [lilToggle]     _Main2ndTexIsMSDF           ("As MSDF", Int) = 0
        [NoScaleOffset] _Main2ndBlendMask           ("Mask", 2D) = "white" {}
        [lilEnum]       _Main2ndTexBlendMode        ("Blend Mode|Normal|Add|Screen|Multiply", Int) = 0
                        _Main2ndEnableLighting      ("Enable Lighting", Range(0, 1)) = 1
                        _Main2ndDissolveMask        ("Dissolve Mask", 2D) = "white" {}
                        _Main2ndDissolveNoiseMask   ("Dissolve Noise Mask", 2D) = "gray" {}
        [lilUVAnim]     _Main2ndDissolveNoiseMask_ScrollRotate ("Scroll", Vector) = (0,0,0,0)
                        _Main2ndDissolveNoiseStrength ("Dissolve Noise Strength", float) = 0.1
        [lilHDR]        _Main2ndDissolveColor       ("Dissolve Color", Color) = (1,1,1,1)
        [lilDissolve]   _Main2ndDissolveParams      ("Dissolve Mode|None|Alpha|UV|Position|Dissolve Shape|Point|Line|Border|Blur", Vector) = (0,0,0.5,0.1)
        [lilDissolveP]  _Main2ndDissolvePos         ("Dissolve Position", Vector) = (0,0,0,0)
        [lilFFFB]       _Main2ndDistanceFade        ("Start|End|Strength|Fix backface", Vector) = (0.1,0.01,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Main3rd
        [lilToggleLeft] _UseMain3rdTex              ("Use Main 3rd", Int) = 0
        [lilHDR]        _Color3rd                   ("Color", Color) = (1,1,1,1)
                        _Main3rdTex                 ("Texture", 2D) = "white" {}
        [lilAngle]      _Main3rdTexAngle            ("Angle", Float) = 0
        [lilEnum]       _Main3rdTex_UVMode          ("UV Mode|UV0|UV1|UV2|UV3|MatCap", Int) = 0
        [lilEnum]       _Main3rdTex_Cull            ("Cull Mode|Off|Front|Back", Int) = 0
        [lilDecalAnim]  _Main3rdTexDecalAnimation   ("Animation|X Size|Y Size|Frames|FPS", Vector) = (1,1,1,30)
        [lilDecalSub]   _Main3rdTexDecalSubParam    ("Ratio X|Ratio Y|Fix Border", Vector) = (1,1,0,1)
        [lilToggle]     _Main3rdTexIsDecal          ("As Decal", Int) = 0
        [lilToggle]     _Main3rdTexIsLeftOnly       ("Left Only", Int) = 0
        [lilToggle]     _Main3rdTexIsRightOnly      ("Right Only", Int) = 0
        [lilToggle]     _Main3rdTexShouldCopy       ("Copy", Int) = 0
        [lilToggle]     _Main3rdTexShouldFlipMirror ("Flip Mirror", Int) = 0
        [lilToggle]     _Main3rdTexShouldFlipCopy   ("Flip Copy", Int) = 0
        [lilToggle]     _Main3rdTexIsMSDF           ("As MSDF", Int) = 0
        [NoScaleOffset] _Main3rdBlendMask           ("Mask", 2D) = "white" {}
        [lilEnum]       _Main3rdTexBlendMode        ("Blend Mode|Normal|Add|Screen|Multiply", Int) = 0
                        _Main3rdEnableLighting      ("Enable Lighting", Range(0, 1)) = 1
                        _Main3rdDissolveMask        ("Dissolve Mask", 2D) = "white" {}
                        _Main3rdDissolveNoiseMask   ("Dissolve Noise Mask", 2D) = "gray" {}
        [lilUVAnim]     _Main3rdDissolveNoiseMask_ScrollRotate ("Scroll", Vector) = (0,0,0,0)
                        _Main3rdDissolveNoiseStrength ("Dissolve Noise Strength", float) = 0.1
        [lilHDR]        _Main3rdDissolveColor       ("Dissolve Color", Color) = (1,1,1,1)
        [lilDissolve]   _Main3rdDissolveParams      ("Dissolve Mode|None|Alpha|UV|Position|Dissolve Shape|Point|Line|Border|Blur", Vector) = (0,0,0.5,0.1)
        [lilDissolveP]  _Main3rdDissolvePos         ("Dissolve Position", Vector) = (0,0,0,0)
        [lilFFFB]       _Main3rdDistanceFade        ("Start|End|Strength|Fix backface", Vector) = (0.1,0.01,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Alpha Mask
        [lilEnumLabel]  _AlphaMaskMode              ("AlphaMask|", Int) = 0
                        _AlphaMask                  ("AlphaMask", 2D) = "white" {}
                        _AlphaMaskScale             ("Scale", Float) = 1
                        _AlphaMaskValue             ("Offset", Float) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // NormalMap
        [lilToggleLeft] _UseBumpMap                 ("Use Normal Map", Int) = 0
        [Normal]        _BumpMap                    ("Normal Map", 2D) = "bump" {}
                        _BumpScale                  ("Scale", Range(-10,10)) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // NormalMap 2nd
        [lilToggleLeft] _UseBump2ndMap              ("Use Normal Map 2nd", Int) = 0
        [Normal]        _Bump2ndMap                 ("Normal Map", 2D) = "bump" {}
        [lilEnum]       _Bump2ndMap_UVMode          ("UV Mode|UV0|UV1|UV2|UV3", Int) = 0
                        _Bump2ndScale               ("Scale", Range(-10,10)) = 1
        [NoScaleOffset] _Bump2ndScaleMask           ("Mask", 2D) = "white" {}

        //----------------------------------------------------------------------------------------------------------------------
        // Anisotropy
        [lilToggleLeft] _UseAnisotropy              ("Use Anisotropy", Int) = 0
        [Normal]        _AnisotropyTangentMap       ("Tangent Map", 2D) = "bump" {}
                        _AnisotropyScale            ("Scale", Range(-1,1)) = 1
        [NoScaleOffset] _AnisotropyScaleMask        ("Scale Mask", 2D) = "white" {}
                        _AnisotropyTangentWidth     ("Tangent Width", Range(0,10)) = 1
                        _AnisotropyBitangentWidth   ("Bitangent Width", Range(0,10)) = 1
                        _AnisotropyShift            ("Shift", Range(-10,10)) = 0
                        _AnisotropyShiftNoiseScale  ("Shift Noise Scale", Range(-1,1)) = 0
                        _AnisotropySpecularStrength ("Specular Strength", Range(0,10)) = 1
                        _Anisotropy2ndTangentWidth  ("2nd Tangent Width", Range(0,10)) = 1
                        _Anisotropy2ndBitangentWidth ("2nd Bitangent Width", Range(0,10)) = 1
                        _Anisotropy2ndShift         ("2nd Shift", Range(-10,10)) = 0
                        _Anisotropy2ndShiftNoiseScale ("2nd Shift Noise Scale", Range(-1,1)) = 0
                        _Anisotropy2ndSpecularStrength ("2nd Specular Strength", Range(0,10)) = 0
                        _AnisotropyShiftNoiseMask   ("Shift Noise Mask", 2D) = "white" {}
        [lilToggle]     _Anisotropy2Reflection      ("Reflection", Int) = 0
        [lilToggle]     _Anisotropy2MatCap          ("MatCap", Int) = 0
        [lilToggle]     _Anisotropy2MatCap2nd       ("MatCap 2nd", Int) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // Backlight
        [lilToggleLeft] _UseBacklight               ("Use Backlight", Int) = 0
        [lilHDR]        _BacklightColor             ("Color", Color) = (0.85,0.8,0.7,1.0)
        [NoScaleOffset] _BacklightColorTex          ("Texture", 2D) = "white" {}
                        _BacklightMainStrength      ("Blend Main", Range(0, 1)) = 0
                        _BacklightNormalStrength    ("Normal Strength", Range(0, 1)) = 1.0
                        _BacklightBorder            ("Border", Range(0, 1)) = 0.35
                        _BacklightBlur              ("Blur", Range(0, 1)) = 0.05
                        _BacklightDirectivity       ("Directivity", Float) = 5.0
                        _BacklightViewStrength      ("View direction strength", Range(0, 1)) = 1
        [lilToggle]     _BacklightReceiveShadow     ("Receive Shadow", Int) = 1
        [lilToggle]     _BacklightBackfaceMask      ("Backface Mask", Int) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // Shadow
        [lilToggleLeft] _UseShadow                  ("Use Shadow", Int) = 0
                        _ShadowStrength             ("Strength", Range(0, 1)) = 1
        [NoScaleOffset] _ShadowStrengthMask         ("Strength", 2D) = "white" {}
        [lilLOD]        _ShadowStrengthMaskLOD      ("LOD", Range(0, 1)) = 0
        [NoScaleOffset] _ShadowBorderMask           ("Border", 2D) = "white" {}
        [lilLOD]        _ShadowBorderMaskLOD        ("LOD", Range(0, 1)) = 0
        [NoScaleOffset] _ShadowBlurMask             ("Blur", 2D) = "white" {}
        [lilLOD]        _ShadowBlurMaskLOD          ("LOD", Range(0, 1)) = 0
        [lilFFFF]       _ShadowAOShift              ("1st Scale|1st Offset|2nd Scale|2nd Offset", Vector) = (1,0,1,0)
        [lilFF]         _ShadowAOShift2             ("3rd Scale|3rd Offset", Vector) = (1,0,1,0)
        [lilToggle]     _ShadowPostAO               ("Post AO", Int) = 0
        [lilEnum]       _ShadowColorType            ("Color Type|Normal|LUT", Int) = 0
                        _ShadowColor                ("Shadow Color", Color) = (0.82,0.76,0.85,1.0)
        [NoScaleOffset] _ShadowColorTex             ("Shadow Color", 2D) = "black" {}
                        _ShadowNormalStrength       ("Normal Strength", Range(0, 1)) = 1.0
                        _ShadowBorder               ("Border", Range(0, 1)) = 0.5
                        _ShadowBlur                 ("Blur", Range(0, 1)) = 0.1
                        _ShadowReceive              ("Receive Shadow", Range(0, 1)) = 0
                        _Shadow2ndColor             ("2nd Color", Color) = (0.68,0.66,0.79,1)
        [NoScaleOffset] _Shadow2ndColorTex          ("2nd Color", 2D) = "black" {}
                        _Shadow2ndNormalStrength    ("2nd Normal Strength", Range(0, 1)) = 1.0
                        _Shadow2ndBorder            ("2nd Border", Range(0, 1)) = 0.15
                        _Shadow2ndBlur              ("2nd Blur", Range(0, 1)) = 0.1
                        _Shadow2ndReceive           ("Receive Shadow", Range(0, 1)) = 0
                        _Shadow3rdColor             ("3rd Color", Color) = (0,0,0,0)
        [NoScaleOffset] _Shadow3rdColorTex          ("3rd Color", 2D) = "black" {}
                        _Shadow3rdNormalStrength    ("3rd Normal Strength", Range(0, 1)) = 1.0
                        _Shadow3rdBorder            ("3rd Border", Range(0, 1)) = 0.25
                        _Shadow3rdBlur              ("3rd Blur", Range(0, 1)) = 0.1
                        _Shadow3rdReceive           ("Receive Shadow", Range(0, 1)) = 0
                        _ShadowBorderColor          ("Border Color", Color) = (1,0.1,0,1)
                        _ShadowBorderRange          ("Border Range", Range(0, 1)) = 0.08
                        _ShadowMainStrength         ("Contrast", Range(0, 1)) = 0
                        _ShadowEnvStrength          ("Environment Strength", Range(0, 1)) = 0
        [lilEnum]       _ShadowMaskType             ("Mask Type|Strength|Flat", Int) = 0
                        _ShadowFlatBorder           ("Border", Range(-2, 2)) = 1
                        _ShadowFlatBlur             ("Blur", Range(0.001, 2)) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // Reflection
        [lilToggleLeft] _UseReflection              ("Use Reflection", Int) = 0
        // Smoothness
                        _Smoothness                 ("Smoothness", Range(0, 1)) = 1
        [NoScaleOffset] _SmoothnessTex              ("Smoothness", 2D) = "white" {}
        // Metallic
        [Gamma]         _Metallic                   ("Metallic", Range(0, 1)) = 0
        [NoScaleOffset] _MetallicGlossMap           ("Metallic", 2D) = "white" {}
        // Reflectance
        [Gamma]         _Reflectance                ("Reflectance", Range(0, 1)) = 0.04
        // Reflection
                        _GSAAStrength               ("GSAA", Range(0, 1)) = 0
        [lilToggle]     _ApplySpecular              ("Apply Specular", Int) = 1
        [lilToggle]     _ApplySpecularFA            ("Apply Specular in ForwardAdd", Int) = 1
        [lilToggle]     _SpecularToon               ("Specular Toon", Int) = 1
                        _SpecularNormalStrength     ("Normal Strength", Range(0, 1)) = 1.0
                        _SpecularBorder             ("Border", Range(0, 1)) = 0.5
                        _SpecularBlur               ("Blur", Range(0, 1)) = 0.0
        [lilToggle]     _ApplyReflection            ("Apply Reflection", Int) = 0
                        _ReflectionNormalStrength   ("Normal Strength", Range(0, 1)) = 1.0
        [lilHDR]        _ReflectionColor            ("Color", Color) = (1,1,1,1)
        [NoScaleOffset] _ReflectionColorTex         ("Color", 2D) = "white" {}
        [lilToggle]     _ReflectionApplyTransparency ("Apply Transparency", Int) = 1
        [NoScaleOffset] _ReflectionCubeTex          ("Cubemap Fallback", Cube) = "black" {}
        [lilHDR]        _ReflectionCubeColor        ("Color", Color) = (0,0,0,1)
        [lilToggle]     _ReflectionCubeOverride     ("Override", Int) = 0
                        _ReflectionCubeEnableLighting ("Enable Lighting", Range(0, 1)) = 1
        [lilEnum]       _ReflectionBlendMode        ("Blend Mode|Normal|Add|Screen|Multiply", Int) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // MatCap
        [lilToggleLeft] _UseMatCap                  ("Use MatCap", Int) = 0
        [lilHDR]        _MatCapColor                ("Color", Color) = (1,1,1,1)
                        _MatCapTex                  ("Texture", 2D) = "white" {}
                        _MatCapMainStrength         ("Blend Main", Range(0, 1)) = 0
        [lilVec2R]      _MatCapBlendUV1             ("Blend UV1", Vector) = (0,0,0,0)
        [lilToggle]     _MatCapZRotCancel           ("Z-axis rotation cancellation", Int) = 1
        [lilToggle]     _MatCapPerspective          ("Fix Perspective", Int) = 1
                        _MatCapVRParallaxStrength   ("VR Parallax Strength", Range(0, 1)) = 1
                        _MatCapBlend                ("Blend", Range(0, 1)) = 1
        [NoScaleOffset] _MatCapBlendMask            ("Mask", 2D) = "white" {}
                        _MatCapEnableLighting       ("Enable Lighting", Range(0, 1)) = 1
                        _MatCapShadowMask           ("Shadow Mask", Range(0, 1)) = 0
        [lilToggle]     _MatCapBackfaceMask         ("Backface Mask", Int) = 0
                        _MatCapLod                  ("Blur", Range(0, 10)) = 0
        [lilEnum]       _MatCapBlendMode            ("Blend Mode|Normal|Add|Screen|Multiply", Int) = 1
        [lilToggle]     _MatCapApplyTransparency    ("Apply Transparency", Int) = 1
                        _MatCapNormalStrength       ("Normal Strength", Range(0, 1)) = 1.0
        [lilToggle]     _MatCapCustomNormal         ("MatCap Custom Normal Map", Int) = 0
        [Normal]        _MatCapBumpMap              ("Normal Map", 2D) = "bump" {}
                        _MatCapBumpScale            ("Scale", Range(-10,10)) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // MatCap 2nd
        [lilToggleLeft] _UseMatCap2nd               ("Use MatCap 2nd", Int) = 0
        [lilHDR]        _MatCap2ndColor             ("Color", Color) = (1,1,1,1)
                        _MatCap2ndTex               ("Texture", 2D) = "white" {}
                        _MatCap2ndMainStrength      ("Blend Main", Range(0, 1)) = 0
        [lilVec2R]      _MatCap2ndBlendUV1          ("Blend UV1", Vector) = (0,0,0,0)
        [lilToggle]     _MatCap2ndZRotCancel        ("Z-axis rotation cancellation", Int) = 1
        [lilToggle]     _MatCap2ndPerspective       ("Fix Perspective", Int) = 1
                        _MatCap2ndVRParallaxStrength ("VR Parallax Strength", Range(0, 1)) = 1
                        _MatCap2ndBlend             ("Blend", Range(0, 1)) = 1
        [NoScaleOffset] _MatCap2ndBlendMask         ("Mask", 2D) = "white" {}
                        _MatCap2ndEnableLighting    ("Enable Lighting", Range(0, 1)) = 1
                        _MatCap2ndShadowMask        ("Shadow Mask", Range(0, 1)) = 0
        [lilToggle]     _MatCap2ndBackfaceMask      ("Backface Mask", Int) = 0
                        _MatCap2ndLod               ("Blur", Range(0, 10)) = 0
        [lilEnum]       _MatCap2ndBlendMode         ("Blend Mode|Normal|Add|Screen|Multiply", Int) = 1
        [lilToggle]     _MatCap2ndApplyTransparency ("Apply Transparency", Int) = 1
                        _MatCap2ndNormalStrength    ("Normal Strength", Range(0, 1)) = 1.0
        [lilToggle]     _MatCap2ndCustomNormal      ("MatCap Custom Normal Map", Int) = 0
        [Normal]        _MatCap2ndBumpMap           ("Normal Map", 2D) = "bump" {}
                        _MatCap2ndBumpScale         ("Scale", Range(-10,10)) = 1

        //----------------------------------------------------------------------------------------------------------------------
        // Rim
        [lilToggleLeft] _UseRim                     ("Use Rim", Int) = 0
        [lilHDR]        _RimColor                   ("Color", Color) = (0.66,0.5,0.48,1)
        [NoScaleOffset] _RimColorTex                ("Texture", 2D) = "white" {}
                        _RimMainStrength            ("Blend Main", Range(0, 1)) = 0
                        _RimNormalStrength          ("Normal Strength", Range(0, 1)) = 1.0
                        _RimBorder                  ("Border", Range(0, 1)) = 0.5
                        _RimBlur                    ("Blur", Range(0, 1)) = 0.65
        [PowerSlider(3.0)]_RimFresnelPower          ("Fresnel Power", Range(0.01, 50)) = 3.5
                        _RimEnableLighting          ("Enable Lighting", Range(0, 1)) = 1
                        _RimShadowMask              ("Shadow Mask", Range(0, 1)) = 0.5
        [lilToggle]     _RimBackfaceMask            ("Backface Mask", Int) = 1
                        _RimVRParallaxStrength      ("VR Parallax Strength", Range(0, 1)) = 1
        [lilToggle]     _RimApplyTransparency       ("Apply Transparency", Int) = 1
                        _RimDirStrength             ("Light direction strength", Range(0, 1)) = 0
                        _RimDirRange                ("Direction range", Range(-1, 1)) = 0
                        _RimIndirRange              ("Indirection range", Range(-1, 1)) = 0
        [lilHDR]        _RimIndirColor              ("Indirection Color", Color) = (1,1,1,1)
                        _RimIndirBorder             ("Indirection Border", Range(0, 1)) = 0.5
                        _RimIndirBlur               ("Indirection Blur", Range(0, 1)) = 0.1

        //----------------------------------------------------------------------------------------------------------------------
        // Glitter
        [lilToggleLeft] _UseGlitter                 ("Use Glitter", Int) = 0
        [lilEnum]       _GlitterUVMode              ("UV Mode|UV0|UV1", Int) = 0
        [lilHDR]        _GlitterColor               ("Color", Color) = (1,1,1,1)
                        _GlitterColorTex            ("Texture", 2D) = "white" {}
        [lilEnum]       _GlitterColorTex_UVMode     ("UV Mode|UV0|UV1|UV2|UV3", Int) = 0
                        _GlitterMainStrength        ("Main Color Strength", Range(0, 1)) = 0
                        _GlitterNormalStrength      ("Normal Strength", Range(0, 1)) = 1.0
                        _GlitterScaleRandomize      ("Scale Randomize", Range(0, 1)) = 0
        [lilToggle]     _GlitterApplyShape          ("Apply Shape", Int) = 0
                        _GlitterShapeTex            ("Texture", 2D) = "white" {}
        [lilVec2]       _GlitterAtras               ("Atras", Vector) = (1,1,0,0)
        [lilToggle]     _GlitterAngleRandomize      ("Angle Randomize", Int) = 0
        [lilGlitParam1] _GlitterParams1             ("Tiling|Particle Size|Contrast", Vector) = (256,256,0.16,50)
        [lilGlitParam2] _GlitterParams2             ("Blink Speed|Angle|Blend Light Direction|Color Randomness", Vector) = (0.25,0,0,0)
                        _GlitterPostContrast        ("Post Contrast", Float) = 1
                        _GlitterSensitivity         ("Sensitivity", Float) = 0.25
                        _GlitterEnableLighting      ("Enable Lighting", Range(0, 1)) = 1
                        _GlitterShadowMask          ("Shadow Mask", Range(0, 1)) = 0
        [lilToggle]     _GlitterBackfaceMask        ("Backface Mask", Int) = 0
        [lilToggle]     _GlitterApplyTransparency   ("Apply Transparency", Int) = 1
                        _GlitterVRParallaxStrength  ("VR Parallax Strength", Range(0, 1)) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // Emmision
        [lilToggleLeft] _UseEmission                ("Use Emission", Int) = 0
        [HDR][lilHDR]   _EmissionColor              ("Color", Color) = (1,1,1,1)
                        _EmissionMap                ("Texture", 2D) = "white" {}
        [lilUVAnim]     _EmissionMap_ScrollRotate   ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilEnum]       _EmissionMap_UVMode         ("UV Mode|UV0|UV1|UV2|UV3|Rim", Int) = 0
                        _EmissionMainStrength       ("Main Color Strength", Range(0, 1)) = 0
                        _EmissionBlend              ("Blend", Range(0,1)) = 1
                        _EmissionBlendMask          ("Mask", 2D) = "white" {}
        [lilUVAnim]     _EmissionBlendMask_ScrollRotate ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilBlink]      _EmissionBlink              ("Blink Strength|Blink Type|Blink Speed|Blink Offset", Vector) = (0,0,3.141593,0)
        [lilToggle]     _EmissionUseGrad            ("Use Gradation", Int) = 0
        [NoScaleOffset] _EmissionGradTex            ("Gradation Texture", 2D) = "white" {}
                        _EmissionGradSpeed          ("Gradation Speed", Float) = 1
                        _EmissionParallaxDepth      ("Parallax Depth", float) = 0
                        _EmissionFluorescence       ("Fluorescence", Range(0,1)) = 0
        // Gradation
        [HideInInspector] _egci ("", Int) = 2
        [HideInInspector] _egai ("", Int) = 2
        [HideInInspector] _egc0 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc1 ("", Color) = (1,1,1,1)
        [HideInInspector] _egc2 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc3 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc4 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc5 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc6 ("", Color) = (1,1,1,0)
        [HideInInspector] _egc7 ("", Color) = (1,1,1,0)
        [HideInInspector] _ega0 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega1 ("", Color) = (1,0,0,1)
        [HideInInspector] _ega2 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega3 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega4 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega5 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega6 ("", Color) = (1,0,0,0)
        [HideInInspector] _ega7 ("", Color) = (1,0,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Emmision2nd
        [lilToggleLeft] _UseEmission2nd             ("Use Emission 2nd", Int) = 0
        [HDR][lilHDR]   _Emission2ndColor           ("Color", Color) = (1,1,1,1)
                        _Emission2ndMap             ("Texture", 2D) = "white" {}
        [lilUVAnim]     _Emission2ndMap_ScrollRotate ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilEnum]       _Emission2ndMap_UVMode      ("UV Mode|UV0|UV1|UV2|UV3|Rim", Int) = 0
                        _Emission2ndMainStrength    ("Main Color Strength", Range(0, 1)) = 0
                        _Emission2ndBlend           ("Blend", Range(0,1)) = 1
                        _Emission2ndBlendMask       ("Mask", 2D) = "white" {}
        [lilUVAnim]     _Emission2ndBlendMask_ScrollRotate ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilBlink]      _Emission2ndBlink           ("Blink Strength|Blink Type|Blink Speed|Blink Offset", Vector) = (0,0,3.141593,0)
        [lilToggle]     _Emission2ndUseGrad         ("Use Gradation", Int) = 0
        [NoScaleOffset] _Emission2ndGradTex         ("Gradation Texture", 2D) = "white" {}
                        _Emission2ndGradSpeed       ("Gradation Speed", Float) = 1
                        _Emission2ndParallaxDepth   ("Parallax Depth", float) = 0
                        _Emission2ndFluorescence    ("Fluorescence", Range(0,1)) = 0
        // Gradation
        [HideInInspector] _e2gci ("", Int) = 2
        [HideInInspector] _e2gai ("", Int) = 2
        [HideInInspector] _e2gc0 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc1 ("", Color) = (1,1,1,1)
        [HideInInspector] _e2gc2 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc3 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc4 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc5 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc6 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2gc7 ("", Color) = (1,1,1,0)
        [HideInInspector] _e2ga0 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga1 ("", Color) = (1,0,0,1)
        [HideInInspector] _e2ga2 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga3 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga4 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga5 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga6 ("", Color) = (1,0,0,0)
        [HideInInspector] _e2ga7 ("", Color) = (1,0,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Parallax
        [lilToggleLeft] _UseParallax                ("Use Parallax", Int) = 0
        [lilToggle]     _UsePOM                     ("Use POM", Int) = 0
        [NoScaleOffset] _ParallaxMap                ("Parallax Map", 2D) = "gray" {}
                        _Parallax                   ("Parallax Scale", float) = 0.02
                        _ParallaxOffset             ("Parallax Offset", float) = 0.5

        //----------------------------------------------------------------------------------------------------------------------
        // Distance Fade
        [lilHDR]        _DistanceFadeColor          ("Color", Color) = (0,0,0,1)
        [lilFFFB]       _DistanceFade               ("Start|End|Strength|Fix backface", Vector) = (0.1,0.01,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // AudioLink
        [lilToggleLeft] _UseAudioLink               ("Use AudioLink", Int) = 0
        [lilFRFR]       _AudioLinkDefaultValue      ("Strength|Blink Strength|Blink Speed|Blink Threshold", Vector) = (0.0,0.0,2.0,0.75)
        [lilEnum]       _AudioLinkUVMode            ("UV Mode|None|Rim|UV|Mask|Mask Spectrum|Position", Int) = 1
        [lilALUVParams] _AudioLinkUVParams          ("Scale|Offset|Angle|Band|Bass|Low Mid|High Mid|Treble", Vector) = (0.25,0,0,0.125)
        [lilVec3]       _AudioLinkStart             ("Start Position", Vector) = (0.0,0.0,0.0,0.0)
        [NoScaleOffset] _AudioLinkMask              ("Mask", 2D) = "blue" {}
        [lilToggle]     _AudioLink2Main2nd          ("Main 2nd", Int) = 0
        [lilToggle]     _AudioLink2Main3rd          ("Main 3rd", Int) = 0
        [lilToggle]     _AudioLink2Emission         ("Emission", Int) = 0
        [lilToggle]     _AudioLink2EmissionGrad     ("Emission Grad", Int) = 0
        [lilToggle]     _AudioLink2Emission2nd      ("Emission 2nd", Int) = 0
        [lilToggle]     _AudioLink2Emission2ndGrad  ("Emission 2nd Grad", Int) = 0
        [lilToggle]     _AudioLink2Vertex           ("Vertex", Int) = 0
        [lilEnum]       _AudioLinkVertexUVMode      ("UV Mode|None|Position|UV|Mask", Int) = 1
        [lilALUVParams] _AudioLinkVertexUVParams    ("Scale|Offset|Angle|Band|Bass|Low Mid|High Mid|Treble", Vector) = (0.25,0,0,0.125)
        [lilVec3]       _AudioLinkVertexStart       ("Start Position", Vector) = (0.0,0.0,0.0,0.0)
        [lilVec3Float]  _AudioLinkVertexStrength    ("Moving Vector|Normal Strength", Vector) = (0.0,0.0,0.0,1.0)
        [lilToggle]     _AudioLinkAsLocal           ("As Local", Int) = 0
        [NoScaleOffset] _AudioLinkLocalMap          ("Local Map", 2D) = "black" {}
        [lilALLocal]    _AudioLinkLocalMapParams    ("BPM|Notes|Offset", Vector) = (120,1,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Dissolve
                        _DissolveMask               ("Dissolve Mask", 2D) = "white" {}
                        _DissolveNoiseMask          ("Dissolve Noise Mask", 2D) = "gray" {}
        [lilUVAnim]     _DissolveNoiseMask_ScrollRotate ("Scroll", Vector) = (0,0,0,0)
                        _DissolveNoiseStrength      ("Dissolve Noise Strength", float) = 0.1
        [lilHDR]        _DissolveColor              ("Dissolve Color", Color) = (1,1,1,1)
        [lilDissolve]   _DissolveParams             ("Dissolve Mode|None|Alpha|UV|Position|Dissolve Shape|Point|Line|Border|Blur", Vector) = (0,0,0.5,0.1)
        [lilDissolveP]  _DissolvePos                ("Dissolve Position", Vector) = (0,0,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Encryption
        [lilToggle]     _IgnoreEncryption           ("Ignore Encryption", Int) = 0
                        _Keys                       ("Keys", Vector) = (0,0,0,0)

        //----------------------------------------------------------------------------------------------------------------------
        // Outline
        [lilHDR]        _OutlineColor               ("Outline Color", Color) = (0.6,0.56,0.73,1)
                        _OutlineTex                 ("Texture", 2D) = "white" {}
        [lilUVAnim]     _OutlineTex_ScrollRotate    ("Angle|UV Animation|Scroll|Rotate", Vector) = (0,0,0,0)
        [lilHSVG]       _OutlineTexHSVG             ("Hue|Saturation|Value|Gamma", Vector) = (0,1,1,1)
        [lilHDR]        _OutlineLitColor            ("Lit Color", Color) = (1.0,0.2,0,0)
        [lilToggle]     _OutlineLitApplyTex         ("Apply Tex", Int) = 0
                        _OutlineLitScale            ("Scale", Float) = 10
                        _OutlineLitOffset           ("Offset", Float) = -8
        [lilToggle]     _OutlineLitShadowReceive    ("Receive Shadow", Int) = 0
        [lilOLWidth]    _OutlineWidth               ("Width", Range(0,1)) = 0.08
        [NoScaleOffset] _OutlineWidthMask           ("Width", 2D) = "white" {}
                        _OutlineFixWidth            ("Fix Width", Range(0,1)) = 0.5
        [lilEnum]       _OutlineVertexR2Width       ("Vertex Color|None|R|RGBA", Int) = 0
        [lilToggle]     _OutlineDeleteMesh          ("Delete Mesh", Int) = 0
        [NoScaleOffset][Normal] _OutlineVectorTex   ("Vector", 2D) = "bump" {}
        [lilEnum]       _OutlineVectorUVMode        ("UV Mode|UV0|UV1|UV2|UV3", Int) = 0
                        _OutlineVectorScale         ("Vector scale", Range(-10,10)) = 1
                        _OutlineEnableLighting      ("Enable Lighting", Range(0, 1)) = 1
                        _OutlineZBias               ("Z Bias", Float) = 0
        [lilToggle]     _OutlineDisableInVR         ("Disable in VR", Int) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // Tessellation
                        _TessEdge                   ("Tessellation Edge", Range(1, 100)) = 10
                        _TessStrength               ("Tessellation Strength", Range(0, 1)) = 0.5
                        _TessShrink                 ("Tessellation Shrink", Range(0, 1)) = 0.0
        [IntRange]      _TessFactorMax              ("Tessellation Max", Range(1, 8)) = 3

        //----------------------------------------------------------------------------------------------------------------------
        // For Multi
        [lilToggleLeft] _UseOutline                 ("Use Outline", Int) = 0
        [lilEnum]       _TransparentMode            ("Rendering Mode|Opaque|Cutout|Transparent|Refraction|Fur|FurCutout|Gem", Int) = 0
        [lilToggle]     _UseClippingCanceller       ("Use Clipping Canceller", Int) = 0
        [lilToggle]     _AsOverlay                  ("As Overlay", Int) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // Save (Unused)
        [HideInInspector]                               _BaseColor          ("Color", Color) = (1,1,1,1)
        [HideInInspector]                               _BaseMap            ("Texture", 2D) = "white" {}
        [HideInInspector]                               _BaseColorMap       ("Texture", 2D) = "white" {}
        [HideInInspector]                               _lilToonVersion     ("Version", Int) = 32

        //----------------------------------------------------------------------------------------------------------------------
        // Advanced
        [lilEnum]                                       _Cull               ("Cull Mode|Off|Front|Back", Int) = 0
        [Enum(UnityEngine.Rendering.BlendMode)]         _SrcBlend           ("SrcBlend", Int) = 1
        [Enum(UnityEngine.Rendering.BlendMode)]         _DstBlend           ("DstBlend", Int) = 1
        [Enum(UnityEngine.Rendering.BlendMode)]         _SrcBlendAlpha      ("SrcBlendAlpha", Int) = 1
        [Enum(UnityEngine.Rendering.BlendMode)]         _DstBlendAlpha      ("DstBlendAlpha", Int) = 10
        [Enum(UnityEngine.Rendering.BlendOp)]           _BlendOp            ("BlendOp", Int) = 0
        [Enum(UnityEngine.Rendering.BlendOp)]           _BlendOpAlpha       ("BlendOpAlpha", Int) = 0
        [Enum(UnityEngine.Rendering.BlendMode)]         _SrcBlendFA         ("ForwardAdd SrcBlend", Int) = 1
        [Enum(UnityEngine.Rendering.BlendMode)]         _DstBlendFA         ("ForwardAdd DstBlend", Int) = 1
        [Enum(UnityEngine.Rendering.BlendMode)]         _SrcBlendAlphaFA    ("ForwardAdd SrcBlendAlpha", Int) = 0
        [Enum(UnityEngine.Rendering.BlendMode)]         _DstBlendAlphaFA    ("ForwardAdd DstBlendAlpha", Int) = 1
        [Enum(UnityEngine.Rendering.BlendOp)]           _BlendOpFA          ("ForwardAdd BlendOp", Int) = 4
        [Enum(UnityEngine.Rendering.BlendOp)]           _BlendOpAlphaFA     ("ForwardAdd BlendOpAlpha", Int) = 4
        [lilToggle]                                     _ZClip              ("ZClip", Int) = 1
        [lilToggle]                                     _ZWrite             ("ZWrite", Int) = 0
        [Enum(UnityEngine.Rendering.CompareFunction)]   _ZTest              ("ZTest", Int) = 4
        [IntRange]                                      _StencilRef         ("Stencil Reference Value", Range(0, 255)) = 0
        [IntRange]                                      _StencilReadMask    ("Stencil ReadMask Value", Range(0, 255)) = 255
        [IntRange]                                      _StencilWriteMask   ("Stencil WriteMask Value", Range(0, 255)) = 255
        [Enum(UnityEngine.Rendering.CompareFunction)]   _StencilComp        ("Stencil Compare Function", Float) = 8
        [Enum(UnityEngine.Rendering.StencilOp)]         _StencilPass        ("Stencil Pass", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)]         _StencilFail        ("Stencil Fail", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)]         _StencilZFail       ("Stencil ZFail", Float) = 0
                                                        _OffsetFactor       ("Offset Factor", Float) = 0
                                                        _OffsetUnits        ("Offset Units", Float) = 0
        [lilColorMask]                                  _ColorMask          ("Color Mask", Int) = 15
        [lilToggle]                                     _AlphaToMask        ("AlphaToMask", Int) = 0
                                                        _lilShadowCasterBias ("Shadow Caster Bias", Float) = 0

        //----------------------------------------------------------------------------------------------------------------------
        // Refraction
                        _RefractionStrength         ("Refraction Strength", Range(-1,1)) = 0.5
        [PowerSlider(3.0)]_RefractionFresnelPower   ("Refraction Fresnel Power", Range(0.01, 10)) = 1.0

        //----------------------------------------------------------------------------------------------------------------------
        //Gem
                        _GemChromaticAberration     ("Chromatic Aberration", Range(0, 1)) = 0.02
                        _GemEnvContrast             ("Environment Contrast", Float) = 2.0
        [lilHDR]        _GemEnvColor                ("Environment Color", Color) = (1,1,1,1)
                        _GemParticleLoop            ("Particle Loop", Float) = 8
        [lilHDR]        _GemParticleColor           ("Particle Color", Color) = (4,4,4,1)
                        _GemVRParallaxStrength      ("VR Parallax Strength", Range(0, 1)) = 1
    }

    SubShader
    {
        Tags {"RenderType" = "Opaque" "Queue" = "Transparent-100" "ShaderModel" = "4.5"}
        HLSLINCLUDE
            #pragma target 4.5
            #pragma fragmentoption ARB_precision_hint_fastest
            #define LIL_GEM
            #define LIL_MULTI
            #define LIL_MULTI_INPUTS_EMISSION
            #define LIL_MULTI_INPUTS_EMISSION_2ND
            #define LIL_MULTI_INPUTS_NORMAL
            #define LIL_MULTI_INPUTS_NORMAL_2ND
            #define LIL_MULTI_INPUTS_ANISOTROPY
            #define LIL_MULTI_INPUTS_MATCAP
            #define LIL_MULTI_INPUTS_MATCAP_2ND
            #define LIL_MULTI_INPUTS_RIM
            #define LIL_MULTI_INPUTS_GLITTER
            #define LIL_MULTI_INPUTS_AUDIOLINK
            #define LIL_MULTI_INPUTS_DISSOLVE

            #pragma skip_variants SHADOWS_SCREEN _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN _ADDITIONAL_LIGHT_SHADOWS SCREEN_SPACE_SHADOWS_ON SHADOW_LOW SHADOW_MEDIUM SHADOW_HIGH SHADOW_VERY_HIGH
            #pragma skip_variants DECALS_OFF DECALS_3RT DECALS_4RT DECAL_SURFACE_GRADIENT _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
            #pragma skip_variants _ADDITIONAL_LIGHT_SHADOWS
            #pragma skip_variants PROBE_VOLUMES_OFF PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma skip_variants _SCREEN_SPACE_OCCLUSION
        ENDHLSL


        // Forward Pre
        Pass
        {
            Name "FORWARD_PRE"
            Tags {"LightMode" = "SRPDefaultUnlit"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            Blend One Zero
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            AlphaToMask [_AlphaToMask]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_instancing

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #define LIL_GEM_PRE
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_forward_gem.hlsl"

            ENDHLSL
        }

        // Forward
        Pass
        {
            Name "FORWARD"
            Tags {"LightMode" = "UniversalForward"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            ColorMask [_ColorMask]
            Offset [_OffsetFactor], [_OffsetUnits]
            BlendOp [_BlendOp], [_BlendOpAlpha]
            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]
            AlphaToMask [_AlphaToMask]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile_vertex _ FOG_LINEAR FOG_EXP FOG_EXP2
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_instancing
            #define LIL_PASS_FORWARD

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Main
            #pragma shader_feature_local GEOM_TYPE_FROND
            #pragma shader_feature_local _EMISSION
            #pragma shader_feature_local GEOM_TYPE_BRANCH
            #pragma shader_feature_local _SUNDISK_SIMPLE
            #pragma shader_feature_local _NORMALMAP
            #pragma shader_feature_local EFFECT_BUMP
            #pragma shader_feature_local SOURCE_GBUFFER
            #pragma shader_feature_local _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature_local _SPECULARHIGHLIGHTS_OFF
            #pragma shader_feature_local GEOM_TYPE_MESH
            #pragma shader_feature_local _METALLICGLOSSMAP
            #pragma shader_feature_local GEOM_TYPE_LEAF
            #pragma shader_feature_local _SPECGLOSSMAP
            #pragma shader_feature_local _MAPPING_6_FRAMES_LAYOUT
            #pragma shader_feature_local _SUNDISK_HIGH_QUALITY

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_forward_gem.hlsl"

            ENDHLSL
        }

        // ShadowCaster
        Pass
        {
            Name "SHADOW_CASTER"
            Tags {"LightMode" = "ShadowCaster"}
            Cull [_Cull]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_instancing
            #define LIL_PASS_SHADOWCASTER

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_shadowcaster.hlsl"

            ENDHLSL
        }

        // DepthOnly
        Pass
        {
            Name "DEPTHONLY"
            Tags {"LightMode" = "DepthOnly"}
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_instancing
            #define LIL_PASS_DEPTHONLY

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_depthonly.hlsl"

            ENDHLSL
        }

        // DepthNormals
        Pass
        {
            Name "DEPTHNORMALS"
            Tags {"LightMode" = "DepthNormals"}
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_instancing
            #define LIL_PASS_DEPTHNORMALS

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_depthnormals.hlsl"

            ENDHLSL
        }

        // Universal2D
        Pass
        {
            Name "UNIVERSAL2D"
            Tags {"LightMode" = "Universal2D"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            ColorMask [_ColorMask]
            Offset [_OffsetFactor], [_OffsetUnits]
            BlendOp [_BlendOp], [_BlendOpAlpha]
            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_universal2d.hlsl"

            ENDHLSL
        }

        // Meta
        Pass
        {
            Name "META"
            Tags {"LightMode" = "Meta"}
            Cull Off

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature EDITOR_VISUALIZATION
            #define LIL_PASS_META

            // Tone correction and emission
            #pragma shader_feature_local _EMISSION
            #pragma shader_feature_local GEOM_TYPE_BRANCH
            #pragma shader_feature_local _SUNDISK_SIMPLE

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_meta.hlsl"

            ENDHLSL
        }

    }
    Fallback "Universal Render Pipeline/Unlit"

    SubShader
    {
        Tags {"RenderType" = "Opaque" "Queue" = "Transparent-100"}
        HLSLINCLUDE
            #pragma target 3.5
            #pragma fragmentoption ARB_precision_hint_fastest
            #define LIL_GEM
            #define LIL_MULTI
            #define LIL_MULTI_INPUTS_EMISSION
            #define LIL_MULTI_INPUTS_EMISSION_2ND
            #define LIL_MULTI_INPUTS_NORMAL
            #define LIL_MULTI_INPUTS_NORMAL_2ND
            #define LIL_MULTI_INPUTS_ANISOTROPY
            #define LIL_MULTI_INPUTS_MATCAP
            #define LIL_MULTI_INPUTS_MATCAP_2ND
            #define LIL_MULTI_INPUTS_RIM
            #define LIL_MULTI_INPUTS_GLITTER
            #define LIL_MULTI_INPUTS_AUDIOLINK
            #define LIL_MULTI_INPUTS_DISSOLVE

            #pragma skip_variants SHADOWS_SCREEN _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN _ADDITIONAL_LIGHT_SHADOWS SCREEN_SPACE_SHADOWS_ON SHADOW_LOW SHADOW_MEDIUM SHADOW_HIGH SHADOW_VERY_HIGH
            #pragma skip_variants DECALS_OFF DECALS_3RT DECALS_4RT DECAL_SURFACE_GRADIENT _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
            #pragma skip_variants _ADDITIONAL_LIGHT_SHADOWS
            #pragma skip_variants PROBE_VOLUMES_OFF PROBE_VOLUMES_L1 PROBE_VOLUMES_L2
            #pragma skip_variants _SCREEN_SPACE_OCCLUSION
        ENDHLSL


        // Forward Pre
        Pass
        {
            Name "FORWARD_PRE"
            Tags {"LightMode" = "SRPDefaultUnlit"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            Blend One Zero
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            AlphaToMask [_AlphaToMask]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #define LIL_GEM_PRE
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_forward_gem.hlsl"

            ENDHLSL
        }

        // Forward
        Pass
        {
            Name "FORWARD"
            Tags {"LightMode" = "UniversalForward"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            ColorMask [_ColorMask]
            Offset [_OffsetFactor], [_OffsetUnits]
            BlendOp [_BlendOp], [_BlendOpAlpha]
            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]
            AlphaToMask [_AlphaToMask]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile_vertex _ FOG_LINEAR FOG_EXP FOG_EXP2
            #pragma multi_compile_instancing
            #define LIL_PASS_FORWARD

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Main
            #pragma shader_feature_local GEOM_TYPE_FROND
            #pragma shader_feature_local _EMISSION
            #pragma shader_feature_local GEOM_TYPE_BRANCH
            #pragma shader_feature_local _SUNDISK_SIMPLE
            #pragma shader_feature_local _NORMALMAP
            #pragma shader_feature_local EFFECT_BUMP
            #pragma shader_feature_local SOURCE_GBUFFER
            #pragma shader_feature_local _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            #pragma shader_feature_local _SPECULARHIGHLIGHTS_OFF
            #pragma shader_feature_local GEOM_TYPE_MESH
            #pragma shader_feature_local _METALLICGLOSSMAP
            #pragma shader_feature_local GEOM_TYPE_LEAF
            #pragma shader_feature_local _SPECGLOSSMAP
            #pragma shader_feature_local _MAPPING_6_FRAMES_LAYOUT
            #pragma shader_feature_local _SUNDISK_HIGH_QUALITY

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_forward_gem.hlsl"

            ENDHLSL
        }

        // ShadowCaster
        Pass
        {
            Name "SHADOW_CASTER"
            Tags {"LightMode" = "ShadowCaster"}
            Cull [_Cull]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #define LIL_PASS_SHADOWCASTER

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_shadowcaster.hlsl"

            ENDHLSL
        }

        // DepthOnly
        Pass
        {
            Name "DEPTHONLY"
            Tags {"LightMode" = "DepthOnly"}
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #define LIL_PASS_DEPTHONLY

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_depthonly.hlsl"

            ENDHLSL
        }

        // DepthNormals
        Pass
        {
            Name "DEPTHNORMALS"
            Tags {"LightMode" = "DepthNormals"}
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #define LIL_PASS_DEPTHNORMALS

            // AlphaMask and Dissolve
            #pragma shader_feature_local GEOM_TYPE_BRANCH_DETAIL

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_depthnormals.hlsl"

            ENDHLSL
        }

        // Universal2D
        Pass
        {
            Name "UNIVERSAL2D"
            Tags {"LightMode" = "Universal2D"}

            Stencil
            {
                Ref [_StencilRef]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilPass]
                Fail [_StencilFail]
                ZFail [_StencilZFail]
            }
            Cull [_Cull]
            ZClip [_ZClip]
            ZWrite [_ZWrite]
            ZTest [_ZTest]
            ColorMask [_ColorMask]
            Offset [_OffsetFactor], [_OffsetUnits]
            BlendOp [_BlendOp], [_BlendOpAlpha]
            Blend [_SrcBlend] [_DstBlend], [_SrcBlendAlpha] [_DstBlendAlpha]

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_universal2d.hlsl"

            ENDHLSL
        }

        // Meta
        Pass
        {
            Name "META"
            Tags {"LightMode" = "Meta"}
            Cull Off

            HLSLPROGRAM

            //----------------------------------------------------------------------------------------------------------------------
            // Build Option
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature EDITOR_VISUALIZATION
            #define LIL_PASS_META

            // Tone correction and emission
            #pragma shader_feature_local _EMISSION
            #pragma shader_feature_local GEOM_TYPE_BRANCH
            #pragma shader_feature_local _SUNDISK_SIMPLE

            // Replace keywords
            #include "Includes/lil_replace_keywords.hlsl"

            //----------------------------------------------------------------------------------------------------------------------
            // Pass
            #include "Includes/lil_pipeline_urp.hlsl"
            #include "Includes/lil_common.hlsl"
            // Insert functions and includes that depend on Unity here

            #include "Includes/lil_pass_meta.hlsl"

            ENDHLSL
        }

    }
    Fallback "Universal Render Pipeline/Unlit"

    CustomEditor "lilToon.lilToonInspector"
}
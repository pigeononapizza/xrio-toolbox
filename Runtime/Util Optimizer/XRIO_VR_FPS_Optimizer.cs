#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Rendering;


public class XRIO_VR_FPS_Optimizer : MonoBehaviour
{
    [EnumToggleButtons] public enum ComponentType { None, MeshRenderers, Colliders };
    #region SubComponent Enums
    [EnumToggleButtons] public enum RendererParameters { Lightmapping, ShadowCastingMode, Material };
    [PropertySpace(SpaceAfter = 10)]
    public enum ColliderType { Mesh, Box, Sphere, Capsule, All };
    #endregion


    [Header("This script is meant to be run in editor")]
    //enums
    public ComponentType componentType;
    bool isMeshRendererMode => componentType == ComponentType.MeshRenderers;
    bool isColliderMode => componentType == ComponentType.Colliders;


    [PropertySpace(SpaceBefore = 10, SpaceAfter = 10), ShowIf("@isMeshRendererMode")]
    public RendererParameters rendererParameters;
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 10), ShowIf("@isColliderMode")]
    public ColliderType colliderType;

    //variables
    bool meshRendsLightmapping => componentType == ComponentType.MeshRenderers && rendererParameters == RendererParameters.Lightmapping;
    [ShowIf(nameof(meshRendsLightmapping))]
    public float LightmapScale = .1f;


    [ShowIf("@isMeshRendererMode && rendererParameters == RendererParameters.ShadowCastingMode")]
    public ShadowCastingMode shadowCastMode = ShadowCastingMode.Off;
    bool isShadowCastMode => rendererParameters == RendererParameters.ShadowCastingMode;

    bool meshRendsShadowCasting => componentType == ComponentType.MeshRenderers && rendererParameters == RendererParameters.ShadowCastingMode;
    [ShowIf(nameof(meshRendsShadowCasting))]
    public bool isStaticShadowCaster = true;

    [ShowIf(nameof(meshRendsShadowCasting))]
    public ReceiveGI receiveGI = ReceiveGI.LightProbes;

    //clean up later 
    [ShowIf("@isMeshRendererMode && rendererParameters == RendererParameters.Material")]
    public Material newMaterial;


    #region Unity Events
    void Start()
    {
        Debug.LogWarning("ContextMenuExecutor Script exists on " + gameObject.name + "\n Please remove if not using");
    }
    #endregion

    [ContextMenu("Run Context Menu Example")]
    void ContextMenuExample()
    {
        print("This is an example of a context menu script");
    }
    public void ChangeMaterialInChildren()
    {

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.material = newMaterial;
        }
    }



    [ShowIf("@rendererParameters == RendererParameters.Lightmapping && isMeshRendererMode"), Button]
    public void ChangeScaleInLightmapInChildren()
    {
        MeshRenderer[] meshRends = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var mr in meshRends)
        {
            mr.scaleInLightmap = LightmapScale;
            print("lightmap scale on: " + mr.gameObject.name + " is now " + LightmapScale);
        }
    }

    [ShowIf("@componentType == ComponentType.Colliders"), HorizontalGroup("Split", 0.5f), Button(ButtonSizes.Medium)]
    public void EnableChildrenColliders() { ChangeCollidersInChildren(true); }
    [ShowIf("@componentType == ComponentType.Colliders"), VerticalGroup("Split/right"), Button(ButtonSizes.Medium)]
    public void DisableChildrenColliders() { ChangeCollidersInChildren(false); }

    public void ChangeCollidersInChildren(bool colliders_Enabled)
    {
        MeshCollider[] meshCols;
        BoxCollider[] boxCols;
        SphereCollider[] sphereCols;
        CapsuleCollider[] capsuleCols;
        switch (colliderType)
        {
            case ColliderType.Mesh:
                meshCols = gameObject.GetComponentsInChildren<MeshCollider>();
                foreach (var col in meshCols)
                {
                    col.enabled = colliders_Enabled;
                    print("Mesh Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
                }
                break;
            case ColliderType.Box:
                boxCols = gameObject.GetComponentsInChildren<BoxCollider>();
                foreach (var col in boxCols)
                {
                    col.enabled = colliders_Enabled;
                    print("Box Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
                }
                break;
            case ColliderType.Sphere:
                sphereCols = gameObject.GetComponentsInChildren<SphereCollider>();
                foreach (var col in sphereCols)
                {
                    col.enabled = colliders_Enabled;
                    print("Sphere Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
                }
                break;
            case ColliderType.Capsule:
                capsuleCols = gameObject.GetComponentsInChildren<CapsuleCollider>();
                foreach (var col in capsuleCols)
                {
                    col.enabled = colliders_Enabled;
                    print("Capsule Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
                }
                break;
            case ColliderType.All:
                ChangeAllColliders();
                break;
        }


        void ChangeAllColliders()
        {
            meshCols = gameObject.GetComponentsInChildren<MeshCollider>();
            foreach (var col in meshCols)
            {
                col.enabled = colliders_Enabled;
                print("Mesh Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
            }
            boxCols = gameObject.GetComponentsInChildren<BoxCollider>();
            foreach (var col in boxCols)
            {
                col.enabled = colliders_Enabled;
                print("Box Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
            }
            sphereCols = gameObject.GetComponentsInChildren<SphereCollider>();
            foreach (var col in sphereCols)
            {
                col.enabled = colliders_Enabled;
                print("Sphere Collider on: " + col.gameObject.name + " is now " + colliders_Enabled);
            }

        }
    }


    #region Delete Collider Methods
    [ShowIf("@colliderType == ColliderType.Mesh && isColliderMode"), Button]
    public void DeleteMeshCollidersInChildren()
    {
        MeshCollider[] meshCols;
        meshCols = gameObject.GetComponentsInChildren<MeshCollider>();
        foreach (var col in meshCols)
        {
            print("Mesh Collider on: " + col.gameObject.name + " was destroyed ");
            DestroyImmediate(col);
        }
    }

    [ShowIf("@colliderType == ColliderType.Box && isColliderMode"), Button]
    public void DeleteBoxCollidersInChildren()
    {
        BoxCollider[] boxCols;
        boxCols = gameObject.GetComponentsInChildren<BoxCollider>();
        foreach (var col in boxCols)
        {
            print("Box Collider on: " + col.gameObject.name + " was destroyed ");
            DestroyImmediate(col);
        }
    }

    [ShowIf("@colliderType == ColliderType.Sphere && isColliderMode"), Button]
    public void DeleteSphereCollidersInChildren()
    {
        SphereCollider[] sphereCols;
        sphereCols = gameObject.GetComponentsInChildren<SphereCollider>();
        foreach (var col in sphereCols)
        {
            print("Sphere Collider on: " + col.gameObject.name + " was destroyed ");
            DestroyImmediate(col);
        }
    }

    [ShowIf("@colliderType == ColliderType.Capsule && isColliderMode"), Button]
    public void DeleteCapsuleCollidersInChildren()
    {
        CapsuleCollider[] capsuleCols;
        capsuleCols = gameObject.GetComponentsInChildren<CapsuleCollider>();
        foreach (var col in capsuleCols)
        {
            print("Capsule Collider on: " + col.gameObject.name + " was destroyed ");
            DestroyImmediate(col);
        }
    }

    [PropertySpace, ShowIf("@isColliderMode"), Button, GUIColor(1f, 0.8f, .4f)]
    public void DeleteAllCollidersInChildren()
    {
        DeleteMeshCollidersInChildren();
        DeleteBoxCollidersInChildren();
        DeleteSphereCollidersInChildren();
        DeleteCapsuleCollidersInChildren();
    }
    #endregion

    [ShowIf("@isMeshRendererMode && rendererParameters == RendererParameters.ShadowCastingMode "), Button]
    public void ChangeShadowCastModeInChildren()
    {
        MeshRenderer[] meshRends = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var mr in meshRends)
        {
            mr.shadowCastingMode = shadowCastMode;
            mr.staticShadowCaster = isStaticShadowCaster;
            try
            {
                mr.receiveGI = receiveGI;
            }
            catch (System.Exception e)
            {
                print("receiveGI not supported on: " + mr.gameObject.name);
                print(e);
            }
            mr.receiveGI = receiveGI;

            print("changing shadowcasting on: " + mr.gameObject.name + " to " + shadowCastMode);
        }
    }
}
#endif

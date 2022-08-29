using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float scroll_Speed = 0.3f;

    private MeshRenderer mesh_Renderer;
    void Awake() {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Scroll();    
    }

    void Scroll() {

        Vector2 Offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        Offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex",Offset);
    }
}

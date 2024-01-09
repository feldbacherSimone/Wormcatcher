using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    [SerializeField] private float ySpeed;
    [SerializeField] private float xSpeed;
    [SerializeField] private Material mat;

    
    void FixedUpdate()
    {
        mat.mainTextureOffset += new Vector2(xSpeed, ySpeed);

        if (Mathf.Abs(mat.mainTextureOffset.x) >= 10)
        {
            mat.mainTextureOffset = new Vector2(0, mat.mainTextureOffset.y);
        }
        if (Mathf.Abs(mat.mainTextureOffset.y) >= 10)
        {
            mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x, 0);
        }
    }
}

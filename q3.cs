namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    public class q3 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            for (int yi = 0; yi < mat.Height; yi++)
            {
                for (int xi = 0; xi < mat.Width; xi++)
                {
                    Vec3b v = mat.At<Vec3b>(yi, xi);
                    Debug.Log(v[0]);
                    float gr = 0.2126f * v[2] + 0.7152f * v[1] + 0.0722f * v[0];
                    if(gr < 128)
                    {
                        gr = 0;
                    }
                    else
                    {
                        gr = 255;
                    }
                    v[0] = (byte)gr;
                    v[1] = (byte)gr;
                    v[2] = (byte)gr;
                    mat.Set<Vec3b>(yi, xi, v);
                }
            }
            Texture2D changedTex = Unity.MatToTexture(mat);
            GetComponent<RawImage>().texture = changedTex;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

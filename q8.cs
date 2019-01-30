namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    public class q8 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            for (int yi = 0; yi < 16; yi++)
            {
                for (int xi = 0; xi < 16; xi++)
                {
                    Vec3b max = new Vec3b();
                    for (int yj = 0; yj < 8; yj++)
                    {
                        for (int xj = 0; xj < 8; xj++)
                        {
                            Vec3b v = mat.At<Vec3b>(yi * 8 + yj, xi * 8 + xj);
                            if (max[0] < v[0]) max[0] = v[0];
                            if (max[1] < v[1]) max[1] = v[1];
                            if (max[2] < v[2]) max[2] = v[2];
                        }
                    }
                    for (int yj = 0; yj < 8; yj++)
                    {
                        for (int xj = 0; xj < 8; xj++)
                        {
                            mat.Set<Vec3b>(yi * 8 + yj, xi * 8 + xj, max);
                        }
                    }
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

﻿namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    using System.Linq;
    public class q4 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            float[] results = new float[256];
            float[,] grs = new float[mat.Height,mat.Width];
            for(int yi = 0; yi < mat.Height; yi++)
            {
                for(int xi = 0; xi < mat.Width; xi++)
                {
                    Vec3b v = mat.At<Vec3b>(yi, xi);
                    float gr = 0.2126f * v[2] + 0.7152f * v[1] + 0.0722f * v[0];
                    grs[yi, xi] = gr;
                }
            }
            for(int thi = 1; thi < 255; thi++)
            {
                int w0 = 0;
                int w1 = 0;
                float M0 = 0;
                float M1 = 0;
                foreach(float gr in grs)
                {
                    if(gr < thi)
                    {
                        w0++;
                        M0 += gr;
                    }
                    else
                    {
                        w1++;
                        M1 += gr;
                    }
                }
                Debug.Log(w0 + w1);
                float tmp0 = w0 == 0 ? 0 : M0 / w0;
                float tmp1 = w1 == 0 ? 0 : M1 / w1;
                results[thi] = ((float)w0 / (mat.Height * mat.Width)) * ((float)w1 / (mat.Height * mat.Width)) * Mathf.Pow(tmp0 - tmp1 , 2);
            }
            int z = 0;
            for(int i = 1; i < 255; i++)
            {
                if (results[i] > results[z]) z = i;
            }
            for(int yi = 0; yi < mat.Height; yi++)
            {
                for(int xi = 0; xi < mat.Width; xi++)
                {
                    if(grs[yi,xi] < z)
                    {
                        Vec3b v = new Vec3b();
                        v[0] = (byte)0;v[1] = (byte)0;v[2] = (byte)0;
                        mat.Set<Vec3b>(yi, xi, v);
                    }
                    else
                    {
                        Vec3b v = new Vec3b();
                        v[0] = (byte)255; v[1] = (byte)255; v[2] = (byte)255;
                        mat.Set<Vec3b>(yi, xi, v);
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

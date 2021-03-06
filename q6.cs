﻿namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    public class q6 : MonoBehaviour
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
                    v[0] = (byte)(ReduceColor(v[0]));
                    v[1] = (byte)(ReduceColor(v[1]));
                    v[2] = (byte)(ReduceColor(v[2]));
                    mat.Set<Vec3b>(yi, xi, v);
                }
            }
            Texture2D changedTex = Unity.MatToTexture(mat);
            GetComponent<RawImage>().texture = changedTex;
        }
        public float ReduceColor (float val)
        {
            if(val < 63)
            {
                return 32;
            }else if(val <127)
            {
                return 96;
            }else if(val < 191)
            {
                return 160;
            }else if(val < 255)
            {
                return 224;
            }
            return -1;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
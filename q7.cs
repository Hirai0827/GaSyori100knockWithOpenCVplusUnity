namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    public class q7 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            for(int yi = 0; yi < 16; yi++)
            {
                for(int xi = 0; xi < 16; xi++)
                {
                    Vector3 sum = new Vector3();
                    for(int yj = 0; yj < 8; yj++)
                    {
                        for(int xj = 0; xj < 8; xj++)
                        {
                            Vec3b v = mat.At<Vec3b>(yi * 8 + yj,xi * 8 + xj);
                            sum[0] += v[0];
                            sum[1] += v[1];
                            sum[2] += v[2];
                        }
                    }
                    Debug.Log(sum[0]);
                    Vec3b ave = new Vec3b();
                    ave[0] = (byte)(sum[0] / 64);
                    ave[1] = (byte)(sum[1] / 64);
                    ave[2] = (byte)(sum[2] / 64);
                   
                    for (int yj = 0; yj < 8; yj++)
                    {
                        for (int xj = 0; xj < 8; xj++)
                        {
                            mat.Set<Vec3b>(yi * 8 + yj, xi * 8 + xj, ave);
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
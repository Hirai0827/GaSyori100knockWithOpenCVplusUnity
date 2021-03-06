﻿namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    using System.Collections.Generic;
    public class q10 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {

            Mat mat = Unity.TextureToMat(this.texture);
            Vector3[,] v = new Vector3[mat.Height, mat.Width];
            for (int yi = 0; yi < mat.Height; yi++)
            {
                for (int xi = 0; xi < mat.Width; xi++)
                {
                    Vec3b vyx = mat.At<Vec3b>(yi, xi);
                    v[yi, xi][0] = vyx[0];
                    v[yi, xi][1] = vyx[1];
                    v[yi, xi][2] = vyx[2];
                }
            }
            v = Median(v, mat.Height, mat.Width);
            for (int yi = 0; yi < mat.Height; yi++)
            {
                for (int xi = 0; xi < mat.Width; xi++)
                {
                    Vec3b vyx = new Vec3b();
                    vyx[0] = (byte)v[yi, xi][0];
                    vyx[1] = (byte)v[yi, xi][1];
                    vyx[2] = (byte)v[yi, xi][2];
                    mat.Set<Vec3b>(yi, xi, vyx);
                }
            }
            Texture2D changedTex = Unity.MatToTexture(mat);
            GetComponent<RawImage>().texture = changedTex;
        }
        public Vector3[,] Median(Vector3[,] target, int height, int width)
        {
            Vector3[,] result = target;
            for (int yi = 0; yi < height; yi++)
            {

                for (int xi = 0; xi < width; xi++)
                {
                    int[,] multiply = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
                    if (xi == 0)
                    {
                        multiply[0, 0] = 0;
                        multiply[1, 0] = 0;
                        multiply[2, 0] = 0;
                    }
                    else if (xi == width - 1)
                    {
                        multiply[0, 2] = 0;
                        multiply[1, 2] = 0;
                        multiply[2, 2] = 0;
                    }
                    if (yi == 0)
                    {
                        multiply[0, 0] = 0;
                        multiply[0, 1] = 0;
                        multiply[0, 2] = 0;
                    }
                    else if (yi == height - 1)
                    {
                        multiply[2, 0] = 0;
                        multiply[2, 1] = 0;
                        multiply[2, 2] = 0;
                    }
                    
                    Debug.Log(multiply[0, 0] + "," + multiply[0, 1] + "," + multiply[0, 2]);
                    Debug.Log(multiply[1, 0] + "," + multiply[1, 1] + "," + multiply[1, 2]);
                    Debug.Log(multiply[2, 0] + "," + multiply[2, 1] + "," + multiply[2, 2]);
                    List<float> tmp_x = new List<float>();
                    List<float> tmp_y = new List<float>();
                    List<float> tmp_z = new List<float>();
                    for (int yj = -1; yj < 2; yj++)
                    {
                        for (int xj = -1; xj < 2; xj++)
                        {
                            if (multiply[yj + 1, xj + 1] != 0)
                            {
                                tmp_x.Add(target[yi + yj, xi + xj][0]);
                                tmp_y.Add(target[yi + yj, xi + xj][1]);
                                tmp_z.Add(target[yi + yj, xi + xj][2]);
                            }
                        }
                    }
                    tmp_x.Sort();
                    tmp_y.Sort();
                    tmp_z.Sort();
                    if(tmp_x.Count % 2 == 0) {
                        result[yi, xi][0] = (tmp_x[tmp_x.Count / 2] + tmp_x[(tmp_x.Count / 2) - 1])/2;
                        result[yi, xi][1] = (tmp_y[tmp_y.Count / 2] + tmp_y[(tmp_y.Count / 2) - 1])/2;
                        result[yi, xi][2] = (tmp_z[tmp_z.Count / 2] + tmp_z[(tmp_z.Count / 2) - 1])/2;
                    }
                    else
                    {
                        result[yi, xi][0] = tmp_x[(tmp_x.Count - 1) / 2];
                        result[yi, xi][1] = tmp_y[(tmp_y.Count - 1) / 2];
                        result[yi, xi][2] = tmp_z[(tmp_z.Count - 1) / 2];
                    }
                }
            }
            return result;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

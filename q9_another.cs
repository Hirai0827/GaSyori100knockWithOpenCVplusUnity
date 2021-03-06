﻿namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    public class q9_another : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            Mat changedMat = new Mat();
            Cv2.GaussianBlur(mat, changedMat, new Size(3,3),1.3,1.3);
            Texture2D changedTex = Unity.MatToTexture(changedMat);
            GetComponent<RawImage>().texture = changedTex;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

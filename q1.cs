﻿namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    public class q1 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            Mat changedMat = new Mat();            
            Cv2.CvtColor(mat, changedMat,ColorConversionCodes.BGR2RGB );
            Texture2D changedTex = Unity.MatToTexture(changedMat);
            GetComponent<RawImage>().texture = changedTex;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

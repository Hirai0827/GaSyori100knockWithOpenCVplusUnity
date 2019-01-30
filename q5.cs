namespace OpenCvSharp
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    public class q5 : MonoBehaviour
    {
        public Texture2D texture;
        // Use this for initialization
        void Start()
        {
            Mat mat = Unity.TextureToMat(this.texture);
            Mat changedMat = new Mat();
            Mat changedMat1 = new Mat();
            Cv2.CvtColor(mat, changedMat, ColorConversionCodes.BGR2HSV);
            for(int yi = 0; yi < mat.Height; yi++)
            {
                for(int xi = 0; xi < mat.Width; xi++)
                {
                    Vec3b v = changedMat.At<Vec3b>(yi, xi);
                    Debug.Log(v[0]);
                    v[0] = (byte)((v[0] - 180) % 360);
                    changedMat.Set<Vec3b>(yi, xi, v);
                }

            }
            Cv2.CvtColor(changedMat,changedMat1, ColorConversionCodes.HSV2BGR);
            Texture2D changedTex = Unity.MatToTexture(changedMat1);
            GetComponent<RawImage>().texture = changedTex;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

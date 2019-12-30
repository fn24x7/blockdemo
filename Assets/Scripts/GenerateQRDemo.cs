using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

namespace GenerateQRDemo
{
    [RequireComponent(typeof(RawImage))]
    public class GenerateQRDemo : MonoBehaviour
    {
        private string QRText = "test";
        private RawImage cRawImage;

        void Start()
        {
            cRawImage = GetComponent<RawImage>();
            
            Texture2D tex = generateQR(QRText);

            cRawImage.texture = tex;
            //cRawImage.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);
            //Debug.Log("Generating QR Code...");
        }
        private static Color32[] Encode(string textForEncoding, int width, int height)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width
                }
            };
            return writer.Write(textForEncoding);
        }

        public Texture2D generateQR(string text)
        {
            var encoded = new Texture2D(256, 256);
            var color32 = Encode(text, encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
            return encoded;
        }
    }
}

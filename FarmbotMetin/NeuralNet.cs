using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace FarmbotMetin
{
    internal class NeuralNet
    {
        private Net Net;
        private string[] LayerNames;
        private string[] outputLayers;
        private string[] classes = new[] { "metinstone" };
        private float nmsThreshhold = 0.4f;
        private float confThreshhold = 0.3f;
        private VectorOfRect currentBoundingBoxes;

        public NeuralNet()
        {
            Net = DnnInvoke.ReadNet("C:\\Users\\thoma\\Downloads\\train_yolo_to_detect_custom_object\\yolo_custom_detection\\yolov3_training_last.weights", 
                "C:\\Users\\thoma\\Downloads\\train_yolo_to_detect_custom_object\\yolo_custom_detection\\yolov3_testing.cfg");
            LayerNames = Net.LayerNames;
            var oL = new List<string>();
            foreach (var unconnectedOutLayer in Net.UnconnectedOutLayers)
            {
                oL.Add(LayerNames[unconnectedOutLayer - 1]);
            }
            outputLayers = oL.ToArray();
        }

        public Bitmap Detect(Bitmap bitmap)
        {
            var mainImg = bitmap.ToImage<Bgr, byte>().Resize(416,416, Inter.Cubic);

            var blob = DnnInvoke.BlobFromImage(mainImg, 1/255.0, swapRB: true);

            Net.SetInput(blob);
            Net.SetPreferableBackend(Emgu.CV.Dnn.Backend.OpenCV);
            Net.SetPreferableTarget(Target.OpenCL);

            var vecOfMat = new VectorOfMat();
            Net.Forward(vecOfMat, outputLayers);

            var boundingBoxes = new VectorOfRect();
            var scores = new VectorOfFloat();
            var indices = new VectorOfInt();

            for (int i = 0; i < vecOfMat.Size; i++)
            {
                var mat = vecOfMat[i];

                var data = mat.GetData().ArrayTo2DList();

                for (int j = 0; j < data.Count; j++)
                {
                    var row = data[j];

                    var rowScores = row.Skip(5).ToArray();

                    var classId = rowScores.ToList().IndexOf(rowScores.Max());

                    var confidence = rowScores[classId];

                    if (confidence > confThreshhold)
                    {
                        var center_x = row[0] * bitmap.Width;
                        var center_y = row[1] * bitmap.Height;

                        var w = row[2] * bitmap.Width;
                        var h = row[3] * bitmap.Height;

                        var x = center_x - w / 2;
                        var y = center_y - h / 2;

                        boundingBoxes.Push(new []
                        {
                            new Rectangle((int)x, (int)y ,(int)w, (int)h)
                        });

                        indices.Push(new []{classId});

                        scores.Push(new []{confidence});
                    }
                }
            }

            var idx = DnnInvoke.NMSBoxes(boundingBoxes.ToArray(), scores.ToArray(), 0.5f, nmsThreshhold);

            var img = bitmap.ToImage<Bgr, byte>();

            currentBoundingBoxes = new VectorOfRect();

            for (int j = 0; j < idx.Length; j++)
            {
                var index = idx[j];
                var bbox = boundingBoxes[index];
                img.Draw(bbox, new Bgr(0, 255, 0), 2);
                CvInvoke.PutText(img, classes[indices[index]], new Point(bbox.X, bbox.Y + 20),
                    FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), 2);
                currentBoundingBoxes.Push(new []{bbox});
            }

            return img.AsBitmap();
        }

        public Rectangle? GetClosestBoundingBoxFromCenter()
        {
            if (currentBoundingBoxes.Size < 1)
                return null;

            var bestItem = new Rectangle();
            var bestScore = 10000;

            foreach (var w in currentBoundingBoxes.ToArray())
            {
                var score = Math.Abs(960 - (w.X + w.Width / 2)) + Math.Abs(540 - (w.Y + w.Height / 2));
                if (score < bestScore)
                {
                    bestItem = w;
                    bestScore = score;
                }
                    
            }

            return bestItem;
        }
    }
}

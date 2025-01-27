using AdminToys;
using Mirror;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NWAPIBulletHoleVisualizer
{
    public static class Utils
    {
        internal static List<PrimitiveObjectToy> SpawnedPrimitives = new List<PrimitiveObjectToy>();
        internal static Dictionary<string, Color> UserToColor = new Dictionary<string, Color>();

        internal static bool LoadedRound = false;
        internal static DateTime RoundStartTime;

        internal static Color[] Colors = new Color[] {
            new Color(0.10588235294117647f, 0.058823529411764705f, 0.0196078431372549f),
            new Color(0.5568627450980392f, 0.8980392156862745f, 0.20392156862745098f),
            new Color(0.10196078431372549f, 0.043137254901960784f, 0.6196078431372549f),
            new Color(0.9490196078431372f, 0.803921568627451f, 0.09019607843137255f),
            new Color(0.45098039215686275f, 0.30196078431372547f, 0.8823529411764706f),
            new Color(0.6588235294117647f, 0.9137254901960784f, 0.3843137254901961f),
            new Color(0.03529411764705882f, 0.0392156862745098f, 0.4549019607843137f),
            new Color(0.3607843137254902f, 0.6470588235294118f, 0.10980392156862745f),
            new Color(0.2f, 0.17254901960784313f, 0.6313725490196078f),
            new Color(0.1607843137254902f, 0.9764705882352941f, 0.6941176470588235f),
            new Color(0.9019607843137255f, 0.07058823529411765f, 0.29411764705882354f),
            new Color(0.058823529411764705f, 0.807843137254902f, 0.5058823529411764f),
            new Color(0.00392156862745098f, 0.33725490196078434f, 0.8431372549019608f),
            new Color(0.9882352941176471f, 0.8941176470588236f, 0.4117647058823529f),
            new Color(0f, 0.4588235294117647f, 0.9725490196078431f),
            new Color(0.7098039215686275f, 0.5843137254901961f, 0.10196078431372549f),
            new Color(0.00392156862745098f, 0.26666666666666666f, 0.6392156862745098f),
            new Color(0.9490196078431372f, 0.47058823529411764f, 0.14901960784313725f),
            new Color(0.00392156862745098f, 0.5137254901960784f, 0.9098039215686274f),
            new Color(0.6862745098039216f, 0.22745098039215686f, 0.00392156862745098f),
            new Color(0.1568627450980392f, 0.9725490196078431f, 0.9882352941176471f),
            new Color(0.5725490196078431f, 0.00784313725490196f, 0.03137254901960784f),
            new Color(0.07058823529411765f, 0.9137254901960784f, 0.9882352941176471f),
            new Color(0.42745098039215684f, 0.011764705882352941f, 0.00784313725490196f),
            new Color(0f, 0.8392156862745098f, 0.8627450980392157f),
            new Color(0.9882352941176471f, 0.34509803921568627f, 0.4823529411764706f),
            new Color(0.06274509803921569f, 0.6196078431372549f, 0.37254901960784315f),
            new Color(0.6745098039215687f, 0.5137254901960784f, 0.9568627450980393f),
            new Color(0.19215686274509805f, 0.5019607843137255f, 0.0784313725490196f),
            new Color(0.43137254901960786f, 0.3176470588235294f, 0.6823529411764706f),
            new Color(0.7294117647058823f, 0.8784313725490196f, 0.5568627450980392f),
            new Color(0.10980392156862745f, 0.12941176470588237f, 0.42745098039215684f),
            new Color(0.9568627450980393f, 0.8117647058823529f, 0.5098039215686274f),
            new Color(0.06274509803921569f, 0.10980392156862745f, 0.3058823529411765f),
            new Color(0.5686274509803921f, 0.9176470588235294f, 0.7607843137254902f),
            new Color(0.6352941176470588f, 0.10196078431372549f, 0.21176470588235294f),
            new Color(0.1803921568627451f, 0.8392156862745098f, 0.9921568627450981f),
            new Color(0.30980392156862746f, 0.011764705882352941f, 0.01568627450980392f),
            new Color(0.5686274509803921f, 0.9647058823529412f, 0.9725490196078431f),
            new Color(0.19607843137254902f, 0.0392156862745098f, 0.023529411764705882f),
            new Color(0.7686274509803922f, 0.9450980392156862f, 0.9647058823529412f),
            new Color(0.027450980392156862f, 0.07450980392156863f, 0.09019607843137255f),
            new Color(0.984313725490196f, 0.8431372549019608f, 0.996078431372549f),
            new Color(0.023529411764705882f, 0.33725490196078434f, 0.0392156862745098f),
            new Color(0.6862745098039216f, 0.5725490196078431f, 0.8666666666666667f),
            new Color(0.24313725490196078f, 0.39215686274509803f, 0.09019607843137255f),
            new Color(0.11372549019607843f, 0.615686274509804f, 0.9450980392156862f),
            new Color(0.6549019607843137f, 0.3254901960784314f, 0.13333333333333333f),
            new Color(0.22745098039215686f, 0.7137254901960784f, 0.9529411764705882f),
            new Color(0.43529411764705883f, 0.19215686274509805f, 0.054901960784313725f),
            new Color(0.17647058823529413f, 0.7372549019607844f, 0.7607843137254902f),
            new Color(0.8627450980392157f, 0.403921568627451f, 0.4588235294117647f),
            new Color(0.06666666666666667f, 0.4549019607843137f, 0.28627450980392155f),
            new Color(1f, 0.5725490196078431f, 0.6666666666666666f),
            new Color(0.023529411764705882f, 0.20784313725490197f, 0.00784313725490196f),
            new Color(0.8588235294117647f, 0.7254901960784313f, 0.9607843137254902f),
            new Color(0.0196078431372549f, 0.1568627450980392f, 0.0196078431372549f),
            new Color(0.9333333333333333f, 0.9058823529411765f, 0.9725490196078431f),
            new Color(0.027450980392156862f, 0.10980392156862745f, 0.023529411764705882f),
            new Color(0.9294117647058824f, 0.9098039215686274f, 0.8823529411764706f),
            new Color(0.050980392156862744f, 0.08235294117647059f, 0.17254901960784313f),
            new Color(0.9686274509803922f, 0.6392156862745098f, 0.40784313725490196f),
            new Color(0.00392156862745098f, 0.3411764705882353f, 0.6549019607843137f),
            new Color(0.4588235294117647f, 0.3686274509803922f, 0.03137254901960784f),
            new Color(0.20784313725490197f, 0.2549019607843137f, 0.49411764705882355f),
            new Color(0.6431372549019608f, 0.5490196078431373f, 0.26666666666666666f),
            new Color(0.19607843137254902f, 0.4470588235294118f, 0.6627450980392157f),
            new Color(0.3137254901960784f, 0.24313725490196078f, 0.03137254901960784f),
            new Color(0.6f, 0.8235294117647058f, 0.9686274509803922f),
            new Color(0.25098039215686274f, 0.1607843137254902f, 0.058823529411764705f),
            new Color(0.8313725490196079f, 0.8823529411764706f, 0.7607843137254902f),
            new Color(0.047058823529411764f, 0.17647058823529413f, 0.2901960784313726f),
            new Color(0.9607843137254902f, 0.807843137254902f, 0.6784313725490196f),
            new Color(0f, 0.15294117647058825f, 0.16470588235294117f),
            new Color(0.984313725490196f, 0.6941176470588235f, 0.7333333333333333f),
            new Color(0f, 0.2901960784313726f, 0.13333333333333333f),
            new Color(0.9686274509803922f, 0.796078431372549f, 0.8117647058823529f),
            new Color(0.1411764705882353f, 0.14901960784313725f, 0.14901960784313725f),
            new Color(0.7215686274509804f, 0.7411764705882353f, 0.796078431372549f),
            new Color(0.4470588235294118f, 0.17254901960784313f, 0.20392156862745098f),
            new Color(0.09019607843137255f, 0.5764705882352941f, 0.6039215686274509f),
            new Color(0.7098039215686275f, 0.4549019607843137f, 0.3176470588235294f),
            new Color(0.09803921568627451f, 0.48627450980392156f, 0.6274509803921569f),
            new Color(0.45098039215686275f, 0.5686274509803921f, 0.3137254901960784f),
            new Color(0.2f, 0.29411764705882354f, 0.45098039215686275f),
            new Color(0.7058823529411765f, 0.6901960784313725f, 0.5607843137254902f),
            new Color(0.011764705882352941f, 0.21568627450980393f, 0.26666666666666666f),
            new Color(0.7098039215686275f, 0.7568627450980392f, 0.7333333333333333f),
            new Color(0.1568627450980392f, 0.2549019607843137f, 0.17254901960784313f),
            new Color(0.7215686274509804f, 0.4392156862745098f, 0.4588235294117647f),
            new Color(0.10196078431372549f, 0.41568627450980394f, 0.4470588235294118f),
            new Color(0.5764705882352941f, 0.4666666666666667f, 0.3686274509803922f),
            new Color(0.06274509803921569f, 0.3058823529411765f, 0.34509803921568627f),
            new Color(0.6392156862745098f, 0.615686274509804f, 0.6039215686274509f),
            new Color(0.25882352941176473f, 0.25098039215686274f, 0.26666666666666666f),
            new Color(0.4666666666666667f, 0.6235294117647059f, 0.5137254901960784f),
            new Color(0.39215686274509803f, 0.37254901960784315f, 0.3686274509803922f),
            new Color(0.4666666666666667f, 0.6039215686274509f, 0.6745098039215687f),
            new Color(0.29411764705882354f, 0.4f, 0.3058823529411765f),
            new Color(0.5294117647058824f, 0.5137254901960784f, 0.5215686274509804f) };

        private static PrimitiveObjectToy _primitiveBaseObject = null;

        internal static PrimitiveObjectToy PrimitiveBaseObject
        {
            get
            {
                if (_primitiveBaseObject == null)
                {
                    _primitiveBaseObject = NetworkClient.prefabs.Values.First(o =>
                    {
                        return o.TryGetComponent(out PrimitiveObjectToy component);
                    }).GetComponent<PrimitiveObjectToy>();
                }
                return _primitiveBaseObject;
            }
        }

        public static Dictionary<ReferenceHub, Visualizer> Visualizers = new Dictionary<ReferenceHub, Visualizer>();

        public static List<Bullet> Bullets = new List<Bullet>();

        public static bool RegenningMap = false;
        public static int NextSeed = -1;

        public static bool IsVisualizing(ReferenceHub hub)
        {
            return Visualizers.ContainsKey(hub);
        }

        public static void StartVisualizing(ReferenceHub hub, bool isAdmin, string searching = null)
        {
            Visualizer comp = hub.gameObject.AddComponent<Visualizer>();
            comp.IsAdmin = isAdmin;
            comp.Search = searching;
            Visualizers.Add(hub, comp);

            if (Visualizers.Count == 1)
            {
                foreach(Bullet bullet in Bullets)
                {
                    SpawnBullet(bullet, UserToColor[bullet.UserId]);
                }
            }
        }

        public static void StopVisualizing(ReferenceHub hub)
        {
            Visualizers.Remove(hub);
            if (hub.gameObject.TryGetComponent(out Visualizer visualizer))
            {
                visualizer.Destroy();
            }

            if (Visualizers.Count == 0)
            {
                foreach (PrimitiveObjectToy primitive in SpawnedPrimitives)
                {
                    NetworkServer.Destroy(primitive.gameObject);
                }
                SpawnedPrimitives.Clear();
            } 
            else
            {
                foreach (PrimitiveObjectToy primitive in SpawnedPrimitives)
                {
                    hub.connectionToClient.Send(new ObjectDestroyMessage() { netId = primitive.netId });
                }
            }
        }

        public static void SetBullets(List<Bullet> bullets)
        {
            Bullets = bullets;
            foreach(Bullet bullet in Bullets)
            {
                if (!UserToColor.ContainsKey(bullet.UserId))
                {
                    UserToColor[bullet.UserId] = Colors[UserToColor.Count % Colors.Length];
                }

                if (Visualizers.Count > 0)
                {
                    SpawnBullet(bullet, UserToColor[bullet.UserId]);
                }
            }
        }

        public static void RegenMap(int seed)
        {
            RegenningMap = true;
            NextSeed = seed;
            Round.Restart();
        }

        public static void Clear() 
        {
            foreach(PrimitiveObjectToy primitive in SpawnedPrimitives)
            {
                NetworkServer.Destroy(primitive.gameObject);
            }
            SpawnedPrimitives.Clear();
            Bullets.Clear();
        }

        public static void AddBulletHole(ReferenceHub hub, Vector3 position)
        {
            Bullet bullet = new Bullet(hub, position);
            Bullets.Add(bullet);
            if (!UserToColor.ContainsKey(bullet.UserId))
            {
                UserToColor[bullet.UserId] = Colors[UserToColor.Count % Colors.Length];
            }

            if (Visualizers.Count > 0)
            {
                SpawnBullet(bullet, UserToColor[bullet.UserId]);
            }
        }

        private static void SpawnBullet(Bullet bullet, Color color)
        {
            PrimitiveObjectToy primitive = UnityEngine.Object.Instantiate(PrimitiveBaseObject);
            SpawnedPrimitives.Add(primitive);
            primitive.transform.position = bullet.Position;
            primitive.transform.localScale = new Vector3(-0.05f, -0.05f, -0.05f);
            primitive.PrimitiveFlags = PrimitiveFlags.Visible;
            NetworkServer.Spawn(primitive.gameObject);
            foreach (ReferenceHub hub in ReferenceHub.AllHubs)
            {
                if (!Visualizers.TryGetValue(hub, out var visualizer) ||
                    !visualizer.CheckSearch(bullet))
                    hub.connectionToClient.Send(new ObjectDestroyMessage() { netId = primitive.netId });
            }
            primitive.NetworkPosition = primitive.transform.position;
            primitive.NetworkScale = primitive.transform.localScale;
            primitive.NetworkPrimitiveType = PrimitiveType.Sphere;
            primitive.NetworkMaterialColor = color;
        }
    }

    public class Bullet
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }

        public Bullet() { }

        public Bullet(ReferenceHub hub, Vector3 position)
        {
            UserId = hub.authManager.UserId;
            Name = hub.nicknameSync.MyNick;
            Position = position;
        }
    }
}

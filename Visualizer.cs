using AdminToys;
using Mirror;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SmartOverlays;
using LiteNetLib4Mirror.Open.Nat;
using System.Runtime.CompilerServices;

namespace NWAPIBulletHoleVisualizer
{
    public class Visualizer : MonoBehaviour
    {
        public bool IsAdmin { get; set; } = false;
        public string Search { get; set; } = null;

        private bool Active = true;
        private ReferenceHub Hub;
        private TempMessage TempMessage;

        private float Timer = 0;

        public const float RefreshTime = 1f;
        public const int Voffset = 5;
        public const MessageAlign Align = MessageAlign.Left;

        public void Awake()
        {
            Hub = ReferenceHub.GetHub(gameObject);
            foreach (PrimitiveObjectToy primitive in Utils.SpawnedPrimitives)
            {
                NetworkServer.SendSpawnMessage(primitive.netIdentity, Hub.connectionToClient);
            }
        }

        public void Update()
        {
            if (!Active)
                return;
            Timer += Time.deltaTime;
            if (Timer >= RefreshTime)
            {
                Timer = 0;
                IEnumerable<Bullet> nearbyBullets = Utils.Bullets.Where(b => (b.Position - Hub.transform.position).sqrMagnitude <= 100f
                    && CheckSearch(b));
                List<string> playerIdsAdded = new List<string>();
                List<string> added = new List<string>();
                foreach(Bullet bullet in nearbyBullets)
                {
                    if (!playerIdsAdded.Contains(bullet.UserId))
                    {
                        playerIdsAdded.Add(bullet.UserId);
                        added.Add($"\n<size=18><align=left><color={Utils.UserToColor[bullet.UserId].ToHex()}>{bullet.Name}{(IsAdmin ? $" ({bullet.UserId})" : "")}</color></align></size>");
                    }
                }

                string message = $"<size=18><align=left>Nearby player bullets:</align></size>{string.Join("", added)}";
                if (!(TempMessage is null) && !TempMessage.Expired) {
                    TempMessage.SetMessages(message, voffset: Voffset, align: Align);
                    TempMessage.Duration = RefreshTime;
                    return;
                }

                TempMessage = Hub.AddTempHint(message, duration: RefreshTime, voffset: Voffset, align: Align);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckSearch(Bullet bullet)
        {
            return string.IsNullOrWhiteSpace(Search) ||
                   string.Equals(bullet.UserId, Search, StringComparison.OrdinalIgnoreCase) || 
                   bullet.Name.IndexOf(Search, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public void Destroy()
        {
            Active = false;
            TempMessage.SetExpired();
            DestroyImmediate(this);
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UniFiSharp.Discovery
{
    public class DeviceInformationV2 : DeviceInformation
    {
        // Message Constants
        private const byte PKT_V2_HWADDR = 0x01,
        PKT_V2_IPINFO = 0x02,
        PKT_V2_FWVERSION = 0x03,
        PKT_V2_UPTIME = 0x0A,
        PKT_V2_HOSTNAME = 0x0B,
        PKT_V2_PLATFORM = 0x0C,
        PKT_V2_ESSID = 0x0D,
        PKT_V2_WMODE = 0x0E,
        PKT_V2_SEQ = 0x12,
        PKT_V2_SOURCE_MAC = 0x13,
        PKT_V2_MODEL = 0x15,
        PKT_V2_SHORT_VER = 0x16,
        PKT_V2_DEFAULT = 0x17,
        PKT_V2_LOCATING = 0x18,
        PKT_V2_DHCPC = 0x19,
        PKT_V2_DHCPC_BOUND = 0x1A,
        PKT_V2_REQ_FW = 0x1B,
        PKT_V2_SSHD_PORT = 0x1C;

        public byte DiscoveredBy { get; private set; }
        public TimeSpan Uptime { get; private set; }
        public int Seq { get; private set; }
        public string SourceMac { get; private set; }
        public string ReqFirmwareVersion { get; private set; }
        public int SshdPort { get; private set; }
        public string ShortVer { get; private set; }
        public bool IsDefault { get; private set; }
        public bool IsLocating { get; private set; }
        public bool IsDhcpClient { get; private set; }
        public bool IsDhcpClientBound { get; private set; }

        internal static async Task<DeviceInformationV2> Parse(IPEndPoint info, byte cmd, byte[] data)
        {
            var msg = new DeviceInformationV2();

            var i = 4;
            UInt16 l = 2;
            msg.DiscoveredBy = 2;

            if (cmd != 6 && cmd != 9 && cmd != 11)
                return null;

            while (i < data.Length)
            {
                var type = data[i++];
                var piece = new byte[] { data[i + 1], data[i] }; // endianness swap
                l = BitConverter.ToUInt16(piece, 0);
                i += 2;

                piece = data.Skip(i).Take(l).ToArray();
                switch (type)
                {
                    case PKT_V2_FWVERSION:
                        msg.Firmware = piece.ToString();
                        break;

                    case PKT_V2_UPTIME:
                        msg.Uptime = TimeSpan.FromSeconds(BitConverter.ToInt32(piece, 0));
                        break;

                    case PKT_V2_HOSTNAME:
                        msg.Hostname = piece.ToString();
                        break;

                    case PKT_V2_IPINFO:
                        if (piece.Length == 10)
                        {
                            msg.MacAddress = BitConverter.ToString(piece.Take(6).ToArray());
                            msg.IPAddress = string.Join(".", piece.Skip(6).Take(4)); // aa.bb.cc.dd
                        }
                        break;

                    case PKT_V2_HWADDR:
                        msg.MacAddress = BitConverter.ToString(piece.Take(6).ToArray());
                        break;

                    case PKT_V2_WMODE:
                        if (piece.Length == 4)
                            msg.WMode = BitConverter.ToInt32(piece, 0);
                        break;

                    case PKT_V2_SEQ:
                        msg.Seq = BitConverter.ToInt32(piece, 0);
                        break;

                    case PKT_V2_SOURCE_MAC:
                        msg.SourceMac = BitConverter.ToString(piece);
                        break;

                    case PKT_V2_DEFAULT:
                        msg.IsDefault = piece[0] == 1;
                        break;

                    case PKT_V2_LOCATING:
                        msg.IsLocating = piece[0] == 1;
                        break;

                    case PKT_V2_DHCPC:
                        msg.IsDhcpClient = piece[0] == 1;
                        break;

                    case PKT_V2_DHCPC_BOUND:
                        msg.IsDhcpClientBound = piece[0] == 1;
                        break;

                    case PKT_V2_SSHD_PORT:
                        msg.SshdPort = BitConverter.ToInt32(piece, 0);
                        break;

                    case PKT_V2_REQ_FW:
                        msg.ReqFirmwareVersion = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V2_SHORT_VER:
                        msg.ShortVer = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V2_ESSID:
                        msg.ESSID = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V2_MODEL:
                        msg.Model = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V2_PLATFORM:
                        msg.Platform = ASCIIEncoding.ASCII.GetString(piece);
                        break;
                }

                i += l;
            }

            // TODO: (unimplemented)
            // cmd == 6 -> set timestamp
            // not sure on precision required for this

            if (cmd == 1 && msg.SshdPort != default(int))
            {
                var udp = new UdpClient();
                await udp.SendAsync(new byte[] { 0x02, 0x0a, 0x00, 0x00 }, 4, info);
            }

            return msg;
        }
    }
}
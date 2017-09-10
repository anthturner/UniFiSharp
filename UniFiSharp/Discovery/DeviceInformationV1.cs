using System;
using System.Linq;
using System.Text;

namespace UniFiSharp.Discovery
{
    public class DeviceInformationV1 : DeviceInformation
    {
        // Message Constants
        private const byte PKT_V1_HWADDR = 0x01,
        PKT_V1_IPINFO = 0x02,
        PKT_V1_FWVERSION = 0x03,
        PKT_V1_USERNAME = 0x06,
        PKT_V1_SALT = 0x07,
        PKT_V1_RND_CHALLENGE = 0x08,
        PKT_V1_CHALLENGE = 0x09,
        PKT_V1_MODEL = 0x14,
        PKT_V1_UPTIME = 0x0A,
        PKT_V1_HOSTNAME = 0x0B,
        PKT_V1_PLATFORM = 0x0C,
        PKT_V1_ESSID = 0x0D,
        PKT_V1_WMODE = 0x0E,
        PKT_V1_WEBUI = 0x0F;

        public int WebPort { get; private set; }
        public bool IsHttps { get; private set; }

        /// <summary>
        /// UniFi Video-specific flag
        /// </summary>
        public bool IsSetup { get; private set; }

        internal static DeviceInformationV1 Parse(byte[] data)
        {
            var msg = new DeviceInformationV1();

            var i = 4;
            while (i < data.Length)
            {
                var type = data[i++];
                var piece = data.Skip(i).Take(2).Reverse().ToArray(); // endianness swap
                var l = BitConverter.ToUInt16(piece, 0);
                i += 2;

                piece = data.Skip(i).Take(l).ToArray();
                switch (type)
                {
                    case PKT_V1_FWVERSION:
                        msg.Firmware = piece.ToString();
                        break;

                    case PKT_V1_HOSTNAME:
                        msg.Hostname = piece.ToString();
                        break;

                    case PKT_V1_IPINFO:
                        if (piece.Length == 10)
                        {
                            msg.MacAddress = BitConverter.ToString(piece.Take(6).ToArray());
                            msg.IPAddress = string.Join(".", piece.Skip(6).Take(4)); // aa.bb.cc.dd
                        }
                        break;

                    case PKT_V1_HWADDR:
                        msg.MacAddress = BitConverter.ToString(piece.Take(6).ToArray());
                        break;

                    case PKT_V1_WEBUI:
                        if (piece.Length == 4)
                        {
                            msg.WebPort = BitConverter.ToInt32(piece, 0) & 0xFFFF;
                            msg.IsHttps = ((BitConverter.ToInt32(piece, 0) >> 16) & 0xFFFF) > 0;
                        }
                        break;

                    case PKT_V1_WMODE:
                        if (piece.Length == 4)
                        {
                            msg.WMode = BitConverter.ToInt32(piece, 0);

                            // Docs indicate this as being UniFi Video-specific
                            // 0x101 or 0x102 means the device has gone through wizard
                            msg.IsSetup = true;
                            if (msg.WMode == 0x100)
                                msg.IsSetup = false;
                        }
                        break;

                    case PKT_V1_ESSID:
                        msg.ESSID = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V1_MODEL:
                        msg.Model = ASCIIEncoding.ASCII.GetString(piece);
                        break;

                    case PKT_V1_PLATFORM:
                        msg.Platform = ASCIIEncoding.ASCII.GetString(piece);
                        break;
                }

                i += 1;
            }

            return msg;
        }
    }
}
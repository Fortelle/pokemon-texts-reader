using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    public class TextFile
    {
        private const ushort KEY_BASIC = 0x7C89;
        private const ushort KEY_INCREASE = 0x2983;
        private const string HexPrefix = "0x";

        public string Name;
        public string Filepath;
        public string[] Entries;

        public TextFile()
        {

        }

        public TextFile(string filename)
        {
            Filepath = filename;
            Name = Path.GetFileNameWithoutExtension(filename);

            var data = File.ReadAllBytes(filename);
            Parse(data);
        }

        public TextFile(byte[] data)
        {
            Parse(data);
        }

        public void Parse(byte[] data)
        {
            using var ms = new MemoryStream(data);
            using var br = new BinaryReader(ms);

            var textSections = br.ReadUInt16();
            var lineCount = br.ReadUInt16();
            var totalLength = br.ReadUInt32();
            var initialKey = br.ReadUInt32();
            var sectionDataOffset = br.ReadInt32();

            var offsetList = new int[lineCount];
            var lengthList = new int[lineCount];
            Entries = new string[lineCount];
            var texts = new List<string>();

            br.BaseStream.Seek(sectionDataOffset, SeekOrigin.Begin);
            br.BaseStream.Seek(4, SeekOrigin.Current);
            for (var i = 0; i < lineCount; i++)
            {
                offsetList[i] = br.ReadInt32();
                lengthList[i] = br.ReadInt16();
                br.BaseStream.Seek(2, SeekOrigin.Current);
            }

            var lineKey = KEY_BASIC;
            for (var i = 0; i < lineCount; i++)
            {
                var length = lengthList[i] * 2;
                var dest = new byte[length];
                Array.Copy(data, sectionDataOffset + offsetList[i], dest, 0, length);

                var charKey = lineKey;
                for (var j = 0; j < length; j += 2)
                {
                    var v = (ushort)(BitConverter.ToUInt16(dest, j) ^ charKey);
                    BitConverter.GetBytes(v).CopyTo(dest, j);
                    charKey = (ushort)(charKey << 3 | charKey >> 13);
                }
                lineKey += KEY_INCREASE;

                var text = GetString(dest);
                Entries[i] = text;
            }
        }

        private string GetString(byte[] data)
        {
            var s = new StringBuilder();
            int i = 0;
            while (i < data.Length)
            {
                ushort val = BitConverter.ToUInt16(data, i);
                i += 2;

                if (val == 0x0000)
                {
                    break;
                }
                else if (val == 0x0010) // dle
                {
                    ushort count = BitConverter.ToUInt16(data, i); i += 2;
                    ushort variable = BitConverter.ToUInt16(data, i); i += 2;

                    if (variable == 0xBE02 || variable == 0xBDFF) // 0xBE02 = wait, 0xBDFF = blank,
                    {
                        ushort time = BitConverter.ToUInt16(data, i);
                        i += 2;
                        s.Append('{' + HexPrefix + variable.ToString("X4") + ':' + HexPrefix + time.ToString("X4") + '}');
                    }
                    else
                    {
                        s.Append('{' + HexPrefix + variable.ToString("X4"));
                        for (var j = 1; j < count; j++)
                        {
                            s.Append(',');
                            ushort arg = BitConverter.ToUInt16(data, i);
                            i += 2;
                            s.Append(HexPrefix + arg.ToString("X4"));
                        }
                        s.Append('}');
                    }
                }
                else if (char.IsControl((char)val))
                {
                    s.Append('[' + HexPrefix + val.ToString("X4") + ']');
                }
                else if (val >= 0xE000 && val <= 0xF8FF) // pua
                {
                    s.Append('[' + HexPrefix + val.ToString("X4") + ']');
                }
                else
                {
                    s.Append((char)val);
                }
            }
            return s.ToString();
        }

    }
}

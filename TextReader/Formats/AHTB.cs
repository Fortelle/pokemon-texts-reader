using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextReader
{
    public class AHTB
    {
        public List<(ulong, string)> Entries;

        public AHTB()
        {
        }

        public AHTB(string filename)
        {
            using var fs = File.OpenRead(filename);
            using var br = new BinaryReader(fs);

            Parse(br);
        }

        public AHTB(byte[] data)
        {
            using var ms = new MemoryStream(data);
            using var br = new BinaryReader(ms);

            Parse(br);
        }


        public void Parse(BinaryReader br)
        {
            var magic = br.ReadChars(4);
            Entries = new List<(ulong, string)>();

            var lineCount = br.ReadUInt32();
            for (var i = 0; i < lineCount; i++)
            {
                var hash = br.ReadUInt64();
                var length = br.ReadUInt16();
                var chars = br.ReadChars(length);
                var text = new string(chars).TrimEnd("\0"[0]);
                Entries.Add((hash, text));
            }
        }

    }
}

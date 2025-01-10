using Force.Crc32;
using System;
using System.Text;

namespace Noobow.Commons.Extensions
{
    public static class ObjectExtension
    {
        private static string instanceId;
        public static void JournalWriteLine(this object obj,string value)
        {
            if (instanceId == null)
            {
                byte[] bytes = new UTF8Encoding().GetBytes(Guid.NewGuid().ToString());
                uint crc32 = Crc32Algorithm.Compute(bytes);
                instanceId = Convert.ToString(crc32, 16);
            }
            Console.WriteLine($"【{obj.GetType().Name}:{instanceId}】{value}");
        }
    }
}

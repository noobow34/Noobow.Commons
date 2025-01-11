using Force.Crc32;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Noobow.Commons.Extensions
{
    public static class ObjectExtension
    {
        private static readonly ConditionalWeakTable<object, string> _instanceIdList = [];

        public static void JournalWriteLine(this object obj,string value)
        {
            if (!_instanceIdList.TryGetValue(obj,out string instanceId)){
                byte[] bytes = new UTF8Encoding().GetBytes(Guid.NewGuid().ToString());
                uint crc32 = Crc32Algorithm.Compute(bytes);
                instanceId = Convert.ToString(crc32, 16);
                _instanceIdList.Add(obj,instanceId);
            }
            Console.WriteLine($"【{obj.GetType().Name}:{instanceId}】{value}");
        }
    }
}

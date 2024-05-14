using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public enum SaltType
    {
        /// <summary>
        /// 在开始位置加盐
        /// </summary>
        Prepend = 0,
        /// <summary>
        /// 在结束位置加盐
        /// </summary>
        Append = 1,
        /// <summary>
        /// 首尾都加盐
        /// </summary>
        Both = 2
    }
}

﻿using System;
using Abp.Rpc.Services;

namespace Abp.Rpc.Server.Attributes
{
    /// <summary>
    /// Rpc服务描述符标记。
    /// </summary>
    public abstract class RpcServiceDescriptorAttribute : Attribute
    {
        /// <summary>
        /// 应用标记。
        /// </summary>
        /// <param name="descriptor">服务描述符。</param>
        public abstract void Apply(ServiceDescriptor descriptor);
    }
}

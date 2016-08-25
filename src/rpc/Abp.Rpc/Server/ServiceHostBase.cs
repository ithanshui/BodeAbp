﻿using System.Net;
using System.Threading.Tasks;
using Abp.Rpc.Messages;
using Abp.Rpc.Transport;

namespace Abp.Rpc.Server
{
    /// <summary>
    /// 服务主机基类。
    /// </summary>
    public abstract class ServiceHostBase : IServiceHost
    {
        #region Field

        private readonly IServiceExecutor _serviceExecutor;

        /// <summary>
        /// 消息监听者。
        /// </summary>
        protected IMessageListener MessageListener { get; } = new MessageListener();

        #endregion Field

        #region Constructor

        protected ServiceHostBase(IServiceExecutor serviceExecutor)
        {
            _serviceExecutor = serviceExecutor;
            MessageListener.Received += MessageListener_Received;
        }

        #endregion Constructor

        #region Implementation of IDisposable

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public abstract void Dispose();

        #endregion Implementation of IDisposable

        #region Implementation of IServiceHost

        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="endPoint">主机终结点。</param>
        /// <returns>一个任务。</returns>
        public abstract Task StartAsync(EndPoint endPoint);

        #endregion Implementation of IServiceHost

        #region Private Method

        private async Task MessageListener_Received(IMessageSender sender, TransportMessage message)
        {
            await _serviceExecutor.ExecuteAsync(sender, message);
        }

        #endregion Private Method
    }
}

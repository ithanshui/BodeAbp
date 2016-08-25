﻿namespace Abp.Rpc.Transport.Simple.Tcp.Framing
{
    public interface IFrameDecoder
    {
        bool TryDecodeFrame(byte[] buffer, int offset, int count, out int frameLength, out byte[] payload, out int payloadOffset, out int payloadCount);
    }
}

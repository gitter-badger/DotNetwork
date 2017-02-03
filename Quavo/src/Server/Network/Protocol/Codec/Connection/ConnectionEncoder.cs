//
// ConnectionEncoder.cs
//
// Author:
//       Jordan Abraham <jordan.abraham1997@gmail.com>
//
// Copyright (c) 2017 Quavo
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System.Collections.Generic;

namespace Quavo.Server.Network.Protocol.Codec.Connection
{

	/// <summary>
	/// The connection encoder for the network.
	/// </summary>
	public class ConnectionEncoder : MessageToByteEncoder<ConnectionResponse>
	{

		/// <summary>
		/// Encode the specified context, message and output.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="message">Message.</param>
		/// <param name="output">Output.</param>
		protected override void Encode(IChannelHandlerContext context, ConnectionResponse message, IByteBuffer output)
		{
			switch (message.Type)
			{
				case ConnectionOpcode.HANDSHAKE_CONNECTION:
					//Start the handshake.
					break;
				case ConnectionOpcode.LOGIN_CONNECTION:
					break;
			}
		}
	}
}

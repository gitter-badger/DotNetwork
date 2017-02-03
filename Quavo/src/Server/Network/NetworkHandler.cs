//
// NetworkHandler.cs
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

using DotNetty.Transport.Channels;
using DotNetty.Common.Utilities;
using Quavo.Server.Network.Listener;
using Quavo.Server.Network.Listener.Impl;

namespace Quavo.Server.Network
{

	/// <summary>
	/// A handler used for sending and recieving channel data.
	/// </summary>
	public class NetworkHandler : ChannelHandlerAdapter
	{

		/// <summary>
		/// The current network listener.
		/// </summary>
		public static readonly AttributeKey<NetworkListener> CURR_LISTENER = AttributeKey<NetworkListener>.ValueOf("listener");

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Quavo.Server.Network.NetworkHandler"/> class.
		/// </summary>
		/// <param name="channel">Channel.</param>
		public NetworkHandler(IChannel channel)
		{
			channel.GetAttribute(CURR_LISTENER).Set(new ConnectionListener());
		}

		/// <summary>
		/// Handles what to do when the channel recieves data.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="message">Message.</param>
		public override void ChannelRead(IChannelHandlerContext context, object message)
		{
			try
			{
				NetworkListener listener = context.Channel.GetAttribute(CURR_LISTENER).Get();
				if (listener != null && context.Channel.Registered)
					listener.MessageRead(context, message);
			}
			finally
			{
				ReferenceCountUtil.Release(message);
			}
		}

		/// <summary>
		/// Channels the read complete.
		/// </summary>
		/// <param name="context">Context.</param>
		public override void ChannelReadComplete(IChannelHandlerContext context)
		{
			context.Flush();
		}

	}
}

//
// NetworkBootstrap.cs
//
// Author:
//       Jordan Abraham <jordan.abraham1997@gmail.com>
//
// Copyright (c) 2017 Quavo 2017
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
using System.Net;
using System.Threading.Tasks;

using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

using Quavo.Server.Network.Protocol.Codec.Connection;

namespace Quavo.Server.Network
{

	/// <summary>
	/// Bootstraps the server network.
	/// </summary>
	public static class NetworkBootstrap
	{

		/// <summary>
		/// Starts the network.
		/// </summary>
		static async Task Bootstrap()
		{
			var boss = new MultithreadEventLoopGroup(1);
			var worker = new MultithreadEventLoopGroup();
			var bootstrap = new ServerBootstrap();
			bootstrap.Group(boss, worker);
			bootstrap.Option(ChannelOption.SoKeepalive, true);
			bootstrap.Channel<TcpServerSocketChannel>();
			bootstrap.ChildHandler(new ActionChannelInitializer<ISocketChannel>((ch) =>
			{
				IChannelPipeline pipeline = ch.Pipeline;

				pipeline.AddLast("decoder", new ConnectionDecoder());
				pipeline.AddLast("encoder", new ConnectionEncoder());
				pipeline.AddLast("handler", new NetworkHandler(ch));

			}));

			await bootstrap.BindAsync(IPAddress.Any, Constants.HOST_PORT);

		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public static void Start()
		{
			Task.Run(Bootstrap).Wait();
		}
		
	}
}

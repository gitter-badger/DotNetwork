//
// ConnectionResponse.cs
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

using Quavo.Server.Network.Protocol.Codec.Connection;

namespace Quavo
{

	/// <summary>
	/// The connection response in the network.
	/// </summary>
	public class ConnectionResponse
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Quavo.ConnectionResponse"/> class.
		/// </summary>
		/// <param name="type">Type.</param>
		public ConnectionResponse(ConnectionOpcode type)
		{
			this.Type = type;
		}

		/// <summary>
		/// Gets the type of the connection.
		/// </summary>
		/// <value>The type.</value>
		public ConnectionOpcode Type { get; }
	}
}

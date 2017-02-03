//
// ConnectionType.cs
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

namespace Quavo.Server.Network.Protocol.Codec.Connection
{

	/// <summary>
	/// The connection type requested by the client.
	/// </summary>
	public static class ConnectionType
	{

		/// <summary>
		/// Gets the type of the connection.
		/// </summary>
		/// <returns>The connection type.</returns>
		/// <param name="opcode">Opcode.</param>
		public static ConnectionOpcode GetConnectionType(int opcode)
		{

			Array values = Enum.GetValues(typeof(ConnectionOpcode));
			foreach (int id in values)
			{
				if (id == opcode)
				{
					return (ConnectionOpcode)id;
				}
			}

			return ConnectionOpcode.NONE;

		}

	}

	/// <summary>
	/// An enumeration representing the different connection types.
	/// </summary>
	public enum ConnectionOpcode
	{

		/// <summary>
		/// No connection id is valid.
		/// </summary>
		NONE,

		/// <summary>
		/// The handshake connection.
		/// </summary>
		HANDSHAKE_CONNECTION = 15,

		/// <summary>
		/// The login connection.
		/// </summary>
		LOGIN_CONNECTION = 14
	}

}

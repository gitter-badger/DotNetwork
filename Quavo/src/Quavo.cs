//
// Constants.cs
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
using System.Threading.Tasks;

using Quavo.Server.Network;

namespace Quavo
{

	/// <summary>
	/// The main class to the server.
	/// </summary>
	class Quavo
	{

		/// <summary>
		/// The version of the client the server supports.
		/// </summary>
		public const int VERSION = 725;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Quavo C# [" + VERSION + "]!");

			Console.WriteLine("Starting the network.");
			NetworkBootstrap.Start();

			Console.WriteLine("Quavo is online!");
			Console.ReadLine();
		}
	}
}

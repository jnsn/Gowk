//
//  Crypter.cs
//
//  Author:
//       Jensen Somers <jensen.somers@gmail.com>
//
//  Copyright (c) 2010 Jensen Somers
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//

using System;
using System.Security.Cryptography;
using System.Text;

namespace Gowk.Security
{
	static internal class Crypter
	{
		private static readonly string m_key = "vQKYcnJNZstZjWbikbuY";

		public static string Encrypt(string password)
		{
			TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
			
			byte[] byteHash = md5Provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(m_key));
			
			desProvider.Key = byteHash;
			desProvider.Mode = CipherMode.ECB;
			
			byte[] byteBuffer = ASCIIEncoding.ASCII.GetBytes(password);
			
			return Convert.ToBase64String(desProvider.CreateEncryptor().TransformFinalBlock(byteBuffer, 0, byteBuffer.Length));
		}

		public static string Decrypt(string password)
		{
			TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
			
			byte[] byteHash = md5Provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(m_key));
			
			desProvider.Key = byteHash;
			desProvider.Mode = CipherMode.ECB;
			
			byte[] byteBuffer = Convert.FromBase64String(password);
			
			return ASCIIEncoding.ASCII.GetString(desProvider.CreateDecryptor().TransformFinalBlock(byteBuffer, 0, byteBuffer.Length));
		}
	}
}


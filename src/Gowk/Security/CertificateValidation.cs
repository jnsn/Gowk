//
//  CertificateValidation.cs
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

using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Gowk.Security
{
	public class CertificateValidation : ICertificatePolicy
	{
		#region ICertificatePolicy implementation

		public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
		{
			// Don't care about any certificate issues, always accept.
			// More information can be found on:
			//    - http://www.mono-project.com/UsingTrustedRootsRespectfully
			//    - http://www.mono-project.com/FAQ:_Security
			
			return true;
		}
		
		#endregion
	}
}

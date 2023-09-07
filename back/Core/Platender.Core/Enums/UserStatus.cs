using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Core.Enums
{
	public enum UserStatus
	{
		/// <summary>
		/// freshly created acc
		/// </summary>
		New,
		/// <summary>
		/// standard - after providing additional registration value like mail auth
		/// </summary>
		Std,
		/// <summary>
		/// Banned
		/// </summary>
		Ban,
		/// <summary>
		/// Timeout
		/// </summary>
		Tmo
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICommentDeleterService
	{
		Task<bool> DeleteComment(Guid commentId);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;

namespace MeowZone.Core.ServiceContracts
{
	public interface IPostsUpdaterService
	{
		Task<PostResponse> UpdatePost(PostUpdateRequest? postUpdateRequest);
	}
}

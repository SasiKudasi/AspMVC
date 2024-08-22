using System;
namespace AspNetMVCProject.Contracts
{
	public record BookResponce(Guid Id,
		string Title,
		string Description,
		decimal Price);
}

using System;
namespace AspNetMVCProject.Contracts
{
    public record BookRequest(
        string Title,
        string Description,
        decimal Price);
}


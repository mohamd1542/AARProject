using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Application.Model;
using AutoMapper;
using MediatR;

namespace AARProject.Application.Commands;
public class CreateRefreshTokenHandler :IRequestHandler<CreateRefreshTokenItem , AuthenticatedResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public CreateRefreshTokenHandler(IApplicationDbContext context ,ITokenService token,IMapper mapper)
    {
        this._context = context;
        this._tokenService = token;
        this._mapper = mapper;
    }
    public async Task<AuthenticatedResponse> Handle(CreateRefreshTokenItem request, CancellationToken cancellationToken)
    {
        var authResponse = new AuthenticatedResponse();

        var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);

        var newRefreshToken = _tokenService.GenerateRefreshToken();

        authResponse.Token = newAccessToken;
        authResponse.RefreshToken = newRefreshToken;
        return authResponse;

    }
}


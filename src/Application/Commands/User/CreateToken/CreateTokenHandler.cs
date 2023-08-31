using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AARProject.Application.Common.Interfaces;
using AARProject.Application.Model;
using AARProject.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AARProject.Application.Commands;
public class CreateTokenHandler : IRequestHandler<CreateTokenItem, LoginModel>
{
    private readonly IApplicationDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public CreateTokenHandler(IApplicationDbContext context, ITokenService token, IMapper mapper)
    {
        _context = context;
        _tokenService = token;
        _mapper = mapper;
    }
    public async Task<LoginModel> Handle(CreateTokenItem request, CancellationToken cancellationToken)
    {
        var auth = new LoginModel();
        var userlog =await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);

        var claims = new List<Claim>
        {
            new Claim("Email", userlog?.Email),
            new Claim("Password", userlog?.Password)
        };
        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();
        auth.AccessToken = accessToken;
        auth.RefresToken = refreshToken;

        return auth;
    }
}

using MediatR;
using MermerUi.Application.DTOs;
using MermerUi.Application.ResponseModels;
using MermerUi.Persistence.Contexts;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Ayricaliklarimiz.Commands;
using MermerUi.Persistence.Features.Ayricaliklarimiz.Queries;
using MermerUi.Persistence.Features.DetaylıUrun.Commands;
using MermerUi.Persistence.Features.DetaylıUrun.Queries;
using MermerUi.Persistence.Features.Hakkimizda.Commands;
using MermerUi.Persistence.Features.Hakkimizda.Queries;
using MermerUi.Persistence.Features.Header.Commands;
using MermerUi.Persistence.Features.Header.Queries;
using MermerUi.Persistence.Features.Referans.Commands;
using MermerUi.Persistence.Features.Referans.Queries;
using MermerUi.Persistence.Features.Urunlerimiz.Commands;
using MermerUi.Persistence.Features.Urunlerimiz.Queries;
using MermerUi.Persistence.Features.User.Commands;
using MermerUi.Persistence.Features.User.Queries;
using MermerUi.Persistence.Features.YıldızUrun.Commands;
using MermerUi.Persistence.Features.YıldızUrun.Queries;
using MermerUi.Persistence.Features.Yorum.Commands;
using MermerUi.Persistence.Features.Yorum.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MermerUi.Persistence.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            service.AddTransient<IRequestHandler<CreateAnasayfaRequest, ServiceResponse<AnasayfaDTO>>, CreateAnasayfaHandler>();
            service.AddTransient<IRequestHandler<DeleteAnasayfaRequest, ServiceResponse<AnasayfaDTO>>, DeleteAnasayfaHandler>();
            service.AddTransient<IRequestHandler<UpdateAnasayfaRequest, ServiceResponse<AnasayfaDTO>>, UpdateAnasayfaHandler>();
            service.AddTransient<IRequestHandler<GetByIdAnasayfaRequest, ServiceResponse<AnasayfaDTO>>, GetByIdAnasayfaHandler>();
            service.AddTransient<IRequestHandler<GetAllAnasayfaRequest, ServiceResponse<List<AnasayfaDTO>>>, GetAllAnasayfaHandler>();


            service.AddTransient<IRequestHandler<CreateAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>, CreateAyricaliklarimizHandler>();
            service.AddTransient<IRequestHandler<DeleteAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>, DeleteAyricaliklarimizHandler>();
            service.AddTransient<IRequestHandler<UpdateAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>, UpdateAyricaliklarimizHandler>();
            service.AddTransient<IRequestHandler<GetByIdAyricaliklarimizRequest, ServiceResponse<AyricaliklarimizDTO>>, GetByIdAyricaliklarimizHandler>();
            service.AddTransient<IRequestHandler<GetAllAyricaliklarimizRequest, ServiceResponse<List<AyricaliklarimizDTO>>>, GetAllAyricaliklarimizHandler>();


            service.AddTransient<IRequestHandler<CreateDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>, CreateDetaylıUrunHandler>();
            service.AddTransient<IRequestHandler<DeleteDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>, DeleteDetaylıUrunHandler>();
            service.AddTransient<IRequestHandler<UpdateDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>, UpdateDetaylıUrunHandler>();
            service.AddTransient<IRequestHandler<GetByIdDetaylıUrunRequest, ServiceResponse<DetaylıUrunDTO>>, GetByIdDetaylıUrunHandler>();
            service.AddTransient<IRequestHandler<GetAllDetaylıUrunRequest, ServiceResponse<List<DetaylıUrunDTO>>>, GetAllDetaylıUrunHandler>();


            service.AddTransient<IRequestHandler<CreateHakkimizdaRequest, ServiceResponse<HakkimizdaDTO>>, CreateHakkimizdaHandler>();
            service.AddTransient<IRequestHandler<DeleteHakkimizdaRequest, ServiceResponse<HakkimizdaDTO>>, DeleteHakkimizdaHandler>();
            service.AddTransient<IRequestHandler<UpdateHakkimizdaRequets, ServiceResponse<HakkimizdaDTO>>, UpdateHakkimizdaHandler>();
            service.AddTransient<IRequestHandler<GetByIdHakkimizdaRequest, ServiceResponse<HakkimizdaDTO>>, GetByIdHakkimizdaHandler>();
            service.AddTransient<IRequestHandler<GetAllHakkimizdaRequest, ServiceResponse<List<HakkimizdaDTO>>>, GetAllHakkimizdaHandler>();

            service.AddTransient<IRequestHandler<CreateHeaderRequest, ServiceResponse<HeaderDTO>>, CreateHeaderHandler>();
            service.AddTransient<IRequestHandler<DeleteHeaderRequest, ServiceResponse<HeaderDTO>>, DeleteHeaderHandler>();
            service.AddTransient<IRequestHandler<UpdateHeaderRequest, ServiceResponse<HeaderDTO>>, UpdateHeaderHandler>();
            service.AddTransient<IRequestHandler<GetByIdHeaderRequest, ServiceResponse<HeaderDTO>>, GetByıdHeaderHandler>();
            service.AddTransient<IRequestHandler<GetAllHeaderRequest, ServiceResponse<List<HeaderDTO>>>, GetAllHeaderHandler>();

            service.AddTransient<IRequestHandler<CreateReferansRequest, ServiceResponse<ReferansDTO>>, CreateReferansHandler>();
            service.AddTransient<IRequestHandler<DeleteReferansRequest, ServiceResponse<ReferansDTO>>, DeleteReferansHandler>();
            service.AddTransient<IRequestHandler<UpdateReferansRequest, ServiceResponse<ReferansDTO>>, UpdateReferansHandler>();
            service.AddTransient<IRequestHandler<GetByIdReferansRequest, ServiceResponse<ReferansDTO>>, GetByIdReferansHandler>();
            service.AddTransient<IRequestHandler<GetAllReferansRequest, ServiceResponse<List<ReferansDTO>>>, GetAllReferansHandler>();

            service.AddTransient<IRequestHandler<CreateUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>, CreateUrunlerimizHandler>();
            service.AddTransient<IRequestHandler<DeleteUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>, DeleteUrunlerimizHandler>();
            service.AddTransient<IRequestHandler<UpdateUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>, UpdateUrunlerimizHandler>();
            service.AddTransient<IRequestHandler<GetByIdUrunlerimizRequest, ServiceResponse<UrunlerimizDTO>>, GetByIdUrunlerimizHandler>();
            service.AddTransient<IRequestHandler<GetAllUrunlerimizRequest, ServiceResponse<List<UrunlerimizDTO>>>, GetAllUrunlerimizHandler>();


            service.AddTransient<IRequestHandler<CreateUserRequest, ServiceResponse<UserDTO>>, CreateUserHandler>();
            service.AddTransient<IRequestHandler<DeleteUserRequest, ServiceResponse<UserDTO>>, DeleteUserHandler>();
            service.AddTransient<IRequestHandler<UpdateUserRequest, ServiceResponse<UserDTO>>, UpdateUserHandler>();
            service.AddTransient<IRequestHandler<GetByIdUserRequest, ServiceResponse<UserDTO>>, GetByIdUserHandler>();
            service.AddTransient<IRequestHandler<GetAllUserRequest, ServiceResponse<List<UserDTO>>>, GetAllUserHandler>();


            service.AddTransient<IRequestHandler<CreateYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>, CreateYıldızUrunHandler>();
            service.AddTransient<IRequestHandler<DeleteYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>, DeleteYıldızUrunHandler>();
            service.AddTransient<IRequestHandler<UpdateYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>, UpdateYıldızUrunHandler>();
            service.AddTransient<IRequestHandler<GetByIdYıldızUrunRequest, ServiceResponse<YıldızUrunDTO>>, GetByIdYıldızUrunHandler>();
            service.AddTransient<IRequestHandler<GetAllYıldızUrunRequest, ServiceResponse<List<YıldızUrunDTO>>>, GetAllYıldızUrunHandler>();


            service.AddTransient<IRequestHandler<CreateYorumRequest, ServiceResponse<YorumDTO>>, CreateYorumHandler>();
            service.AddTransient<IRequestHandler<DeleteYorumRequest, ServiceResponse<YorumDTO>>, DeleteYorumHandler>();
            service.AddTransient<IRequestHandler<UpdateYorumRequest, ServiceResponse<YorumDTO>>, UpdateYorumHandler>();
            service.AddTransient<IRequestHandler<GetByIdYorumRequest, ServiceResponse<YorumDTO>>, GetByIdYorumHanler>();
            service.AddTransient<IRequestHandler<GetAllYorumRequest, ServiceResponse<List<YorumDTO>>>, GetAllYorumHandler>();

            service.AddScoped<MermerDbContext>();
            return service;
        }
    }
}

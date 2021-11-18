using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.BusinessHelpers.MailHelper;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.MailHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DailyReportHelper>().As<IDailyReportHelper>();

            builder.RegisterType<DebitManager>().As<IDebitService>();
            builder.RegisterType<EfDebitDal>().As<IDebitDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<DebitStatusManager>().As<IDebitStatusService>();
            builder.RegisterType<EfDebitStatusDal>().As<IDebitStatusDal>();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();

            builder.RegisterType<HardwareManager>().As<IHardwareService>();
            builder.RegisterType<EfHardwareDal>().As<IHardwareDal>();

            builder.RegisterType<LabelManager>().As<ILabelService>();
            builder.RegisterType<EfLabelDal>().As<ILabelDal>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();

            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<FileHelper>().As<IFileHelper>();

            builder.RegisterType<ImageManager>().As<IImageService>();
            builder.RegisterType<EfImageDal>().As<IImageDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}

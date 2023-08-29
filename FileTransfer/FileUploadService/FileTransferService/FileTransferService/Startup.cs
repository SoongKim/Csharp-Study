using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileTransferService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // 서비스 구성 작업 수행
        }

        public void Configure(IApplicationBuilder app)
        {
            // 애플리케이션 파이프라인 구성 작업 수행
            app.UseExceptionHandler("/Home/Error"); // 이 부분을 사용하여 오류 페이지 경로를 지정할 수 있습니다.
        }
    }
}
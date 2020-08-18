using MagomesBank.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagomesBank.Domain.Services.Jobs
{
    public class ServiceRendimentoDiarioJob : IHostedService
    {
        private Timer _timer;
		public IServiceScopeFactory _serviceScopeFactory;

        /* IHostedService em si não é criado em um escopo de injeção de dependência.
        Como resultado disso, você não pode criar dependências declaradas no escopo de ID.
        Por isso o uso de scope factory */
        public ServiceRendimentoDiarioJob(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}

        //Agenda o serviço para rodar todos os dias 00:01
        public Task StartAsync(CancellationToken cancellationToken)
        {
            TimeSpan interval = TimeSpan.FromHours(24);

            var nextRunTime = DateTime.Today.AddDays(1).AddMinutes(1);
            var curTime = DateTime.Now;
            var firstInterval = nextRunTime.Subtract(curTime);

            Action action = () =>
            {
                var t1 = Task.Delay(firstInterval);
                t1.Wait();

                _timer = new Timer(
                    RentabilizarContasCorrentes,
                    null,
                    TimeSpan.Zero,
                    interval
                );
            };

            Task.Run(action);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void RentabilizarContasCorrentes(object state)
        {
			using (var scope = _serviceScopeFactory.CreateScope())
			{
				var service = scope.ServiceProvider.GetService<IServiceRendimentoDiario>();
				service.RentabilizarContasCorrentes();
			}
        }
    }
}

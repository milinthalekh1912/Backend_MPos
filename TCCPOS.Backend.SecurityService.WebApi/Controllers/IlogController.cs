using System.Diagnostics;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    public class IlogController
    {
        private ILogger _logger;
        public string route { get; set; }
        public string method { get; set; }
        public string  parameter { get; set; }
        public Stopwatch timer { get; set; }

        public IlogController(string route, string method, string? parameter, ILogger logger)
        {
            this.route = route;
            this.method = method;
            this.parameter = parameter ?? "";
            _logger = logger;
            timer = new Stopwatch();
        }

        public void logStart()
        {
            timer.Start();
            _logger.LogInformation("Parameter : {0}", parameter);
            _logger.LogInformation("{0} Method {1} start at : {2}", route, method, DateTime.Now);
        }

        public void logStop()
        {
            timer.Stop();
            _logger.LogInformation("end at : {0} Time estimate : {1} second", DateTime.Now, timer.Elapsed.ToString(@"hh\:mm\:ss"));

        }
    }
}

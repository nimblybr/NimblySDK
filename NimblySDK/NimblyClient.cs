using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NimblySDK
{
    public class NimblyClient
    {
        public string App { get; set; }
        public string Usr { get; set; }
        public int IDUsr { get; set; }
        public string Hash { get; set; }

        public string C { get; set; }
        public string CN { get; set; }
#if DEBUG
        private const string apiBaseURL = "http://localhost:53082/";
#else
        private const string apiBaseURL = "https://api.nimbly.com.br/";
#endif

        /// <summary>
        /// Chama uma função da API usando o endpoint especificado.
        /// </summary>
        /// <param name="endpoint">Exemplo: api/ping</param>
        /// <param name="queryString">Especifique os parâmetros que serão enviados no QueryString</param>
        /// <returns></returns>
        public Result Get(string endpoint, QueryParams queryString = null)
        {
            if ((String.IsNullOrWhiteSpace(C)) && (String.IsNullOrWhiteSpace(CN)))
                return new Result() { ErrorMessage = "Especifique o C ou CN para prosseguir." };

            using (WebClient wcCli = new WebClient())
            {
                wcCli.Headers.Add("App", App);
                wcCli.Headers.Add("Usr", Usr);
                wcCli.Headers.Add("IDUsr", IDUsr.ToString());
                wcCli.Headers.Add("Hash", Hash);
                if (!String.IsNullOrWhiteSpace(C))
                    wcCli.Headers.Add("C", C);
                else
                    wcCli.Headers.Add("CN", CN);

                try
                {
                    byte[] retorno = wcCli.DownloadData(apiBaseURL + endpoint + (queryString != null ? "?" + queryString.ToQueryString() : ""));
                    return new Result()
                    {
                        Content = Encoding.UTF8.GetString(retorno),
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    return new Result() { ErrorMessage = ex.Message };
                }
            }
        }

        /// <summary>
        /// Envia dados de um formulário através do método POST.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public Result Post(string endpoint, NameValueCollection body = null)
        {
            if ((String.IsNullOrWhiteSpace(C)) && (String.IsNullOrWhiteSpace(CN)))
                return new Result() { ErrorMessage = "Especifique o C ou CN para prosseguir." };

            using (WebClient wcCli = new WebClient())
            {
                wcCli.Headers.Add("App", App);
                wcCli.Headers.Add("Usr", Usr);
                wcCli.Headers.Add("IDUsr", IDUsr.ToString());
                wcCli.Headers.Add("Hash", Hash);
                if (!String.IsNullOrWhiteSpace(C))
                    wcCli.Headers.Add("C", C);
                else
                    wcCli.Headers.Add("CN", CN);

                try
                {
                    byte[] retorno = wcCli.UploadValues(apiBaseURL + endpoint, body);
                    return new Result()
                    {
                        Content = Encoding.UTF8.GetString(retorno),
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    return new Result() { ErrorMessage = ex.Message };
                }
            }
        }

        public class Result
        {
            public string Content { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace WinFormsApp1
{
    public class RequestsHandler
    {
        HttpClient httpClient = new HttpClient();

        public async Task<Response1> GetMetadata(string doi)
        {
            Response1 desRes;

            using HttpResponseMessage response = await httpClient.GetAsync($"https://api.crossref.org/works/{doi.Replace("https://doi.org/", "")}");
            string content = await response.Content.ReadAsStringAsync();

            try
            {
                desRes = JsonSerializer.Deserialize<Response1>(content);
            }
            catch (Exception ex)
            {
                desRes = new Response1 { status = "error"};
            }
            return desRes;
        }

        //author[x].given + " " + author[x].family - автор x
        //title - название
        //container_title - название журнала
        //license[0].start.date.Substring(0, 4) - год публикации
    }
}

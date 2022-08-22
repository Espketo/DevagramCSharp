using DevagramCSharp.Dtos;
using System.Net.Http.Headers;

namespace DevagramCSharp.Services
{
    public class CosmicService
    {
        public string EnviarImagen(ImagemDto imagemdto)
        {
            Stream imagem = imagemdto.Imagem.OpenReadStream();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eRUjtK6pRgHKiTFDQjS5fWb1GCqX8biUFI8YXEkucOAqqGahUy");

            var request = new HttpRequestMessage(HttpMethod.Post, "file");
            var conteudo = new MultipartFormDataContent
            {
                {new StreamContent(imagem), "media", imagemdto.Nome }
            };

            request.Content = conteudo;
            var retornoreq = client.PostAsync("https://upload.cosmicjs.com/v2/buckets/devaria-projetos-devagram/media", request.Content).Result;

            var urlretorno = retornoreq.Content.ReadFromJsonAsync<CosmicRespostaDto>();

            return urlretorno.Result.media.url;
        }
    }
}

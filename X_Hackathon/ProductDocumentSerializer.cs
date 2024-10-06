using System.Text;
using System.Text.Json;
using X_Hackathon.Domain;

namespace X_Hackathon
{
    public class ProductDocumentSerializer
    {

        public async Task<IEnumerable<T>> SerializeAsync<T>(string json)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return await JsonSerializer.DeserializeAsyncEnumerable<T>(stream)
                    .ToListAsync();
            }
        }
    }
}

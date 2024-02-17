using Newtonsoft.Json;

namespace UMP.DocumentFlow.Dtos.Mappers.DataFormats
{
    public class JsonDocumentFullInfoDTOMapper : IDataFormatDocumentFullInfoDTOMapper
    {
        public DocumentFullInfoDTO MapDocumentFullInfoDTO(string formattedText)
        {
            return JsonConvert.DeserializeObject<DocumentFullInfoDTO>(formattedText);
        }
    }
}
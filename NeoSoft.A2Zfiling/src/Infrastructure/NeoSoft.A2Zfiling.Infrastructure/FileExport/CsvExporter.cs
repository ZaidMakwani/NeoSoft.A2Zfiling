using NeoSoft.A2Zfiling.Application.Contracts.Infrastructure;
using CsvHelper;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;

namespace NeoSoft.A2Zfiling.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter,new CultureInfo(""));
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}

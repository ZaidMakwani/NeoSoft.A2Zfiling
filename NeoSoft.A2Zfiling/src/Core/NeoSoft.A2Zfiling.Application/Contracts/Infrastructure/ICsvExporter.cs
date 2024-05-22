using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace NeoSoft.A2Zfiling.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}

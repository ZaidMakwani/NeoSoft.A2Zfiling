using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using NeoSoft.A2Zfiling.Infrastructure.FileExport;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace NeoSoft.A2Zfiling.Infrastructure.UnitTests.FileExport
{
    public class CsvExporterTests
    {
        [Fact]
        public void ExportEventsToCsv()
        {
            var exporter = new CsvExporter();

            var result = exporter.ExportEventsToCsv(new List<EventExportDto>());

            result.ShouldNotBeNull();
            result.ShouldBeOfType<byte[]>();
        }
    }
}

using Tap.Solid.Dip.ReportExporters;

namespace Tap.Solid.Dip.Services
{
    public class ReportService : IReportService
    {
        public void GenerateReport()
        {
            var studentsRepository = new StudentRepository();
            var students = studentsRepository.GetAll();

            var reportExporter = new PdfReportExporter();
            reportExporter.Export(students);
        }
    }
}

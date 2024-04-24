using System.Text;

namespace LR9_Chupyna_ASP_402
{
    public interface IDataPresentationService
    {
        string GetDataTable(IEnumerable<DataObject> dataObjects);
    }

    public class DataPresentationService : IDataPresentationService
    {
        public string GetDataTable(IEnumerable<DataObject> dataObjects)
        {
            var sb = new StringBuilder();

            sb.Append("<table border='1'>");
            sb.Append("<tr><th>ID</th><th>Name</th><th>Price</th></tr>");
            foreach (var obj in dataObjects)
            {
                sb.Append($"<tr><td>{obj.ID}</td><td>{obj.Name}</td><td>{obj.Price}</td></tr>");
            }
            sb.Append("</table>");

            return sb.ToString();
        }
    }
}

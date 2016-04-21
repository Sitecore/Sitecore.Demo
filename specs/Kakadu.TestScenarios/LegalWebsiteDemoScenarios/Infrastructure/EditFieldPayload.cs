using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.HelperService;

namespace ClassLibrary1.Infrastructure
{
  public class EditFieldPayload
  {
    public string ItemIdOrPath { get; set; }
    public string FieldName { get; set; }
    public string FieldValue { get; set; }
    public Database Database { get; set; }
  }
}

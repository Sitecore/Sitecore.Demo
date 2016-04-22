using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Infrastructure
{
  public class TestCleanupAction
  {
    public ActionType ActionType { get; set; }
    public object Payload { get; set; }

    public T GetPayload<T>() where T : class
    {
      return Payload as T;
    }
  }
}

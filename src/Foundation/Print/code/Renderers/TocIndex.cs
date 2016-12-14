

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TocIndex.cs" company="Sitecore Corporation">
//   Copyright (C) 2012 by Sitecore Corporation
// </copyright>
// <summary>
//   Defines the toc index class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using Sitecore.PrintStudio.PublishingEngine;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.PrintStudio.PublishingEngine.Helpers;

namespace Sitecore.Foundation.Print.Renderers
{

  /// <summary>
  /// Defines the toc index class.
  /// </summary>
  public class TocIndex : XmlContentRenderer
  {
    /// <summary>
    /// Gets or sets the name of the index.
    /// </summary>
    /// <value>
    /// The name of the index.
    /// </value>
    public string IndexName { get; set; }

    /// <summary>
    /// Gets or sets the replace var.
    /// </summary>
    /// <value>
    /// The replace var.
    /// </value>
    public string ReplaceVar { get; set; }

    /// <summary>
    /// Parses the content.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    /// <returns>
    /// The content.
    /// </returns>
    protected override string ParseContent(PrintContext printContext)
    {
      string content = base.ParseContent(printContext);

      IDictionary<string, string> variables = new Dictionary<string, string>();

      int tocIndex = 0;
      if (printContext.Settings.Parameters.ContainsKey(this.IndexName))
      {
        tocIndex = (int)printContext.Settings.Parameters[this.IndexName];
      }

      variables.Add(this.ReplaceVar, tocIndex.ToString());
      ReplaceVariables(ref content, variables);

      printContext.Settings.Parameters[this.IndexName] = tocIndex + 1;
     // Logger.Info("******ToC Index is at:" + tocIndex.ToString());
     // Logger.Info("******ToC Content is:" + content.ToString());

      return content;
    }
    internal static void ReplaceVariables(ref string input, IDictionary<string, string> variables)
    {
      input = variables.Aggregate(input, (current, variable) => current.Replace(variable.Key, variable.Value));
    }
  }
}

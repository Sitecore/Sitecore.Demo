namespace Sitecore.Feature.Brochure.Services
{
  using System;
  using System.IO;
  using System.Linq;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Foundation.Print.Services;

  public class GenerateBrochureFileService
  {
    public IBrochureItemsRepository BrochureItemsRepository { get; }
    public GenerateFileService GenerateFileService { get; set; }

    public GenerateBrochureFileService() : this(new BrochureItemsRepository(), new GenerateFileService())
    {
      
    }

    private GenerateBrochureFileService(IBrochureItemsRepository brochureItemsRepository, GenerateFileService generateFileService)
    {
      BrochureItemsRepository = brochureItemsRepository;
      GenerateFileService = generateFileService;
    }

    public FileInfo GenerateBrochureFile()
    {
      var pxmProjectPath = "/sitecore/Print Studio/Print Studio Projects/Legal/PXM on Demand";
      var itemIDs = BrochureItemsRepository.Get().Items.Select(f => f.ItemID);
      var fileName = $"CR_Practise_Areas_{DateTime.Now.Ticks}";

      return GenerateFileService.GenerateFile(pxmProjectPath, itemIDs, fileName);
    }
  }
}
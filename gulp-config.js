module.exports = function() {
  var instanceRoot = "C:\\websites\\Habitat.dev.local";
  var config = {
    websiteRoot: instanceRoot + "\\Website",
    sitecoreLibraries: instanceRoot + "\\Website\\bin",
    licensePath: instanceRoot + "\\Data\\license.xml",
    solutionName: "Sitecore.Demo",
    buildConfiguration: "Debug",
    runCleanBuilds: false
  };
  return config;
}
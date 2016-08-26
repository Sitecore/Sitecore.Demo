module.exports = function() {
  var instanceRoot = "C:\\inetpub\\wwwroot\\Habitat.8.2.dev.local";
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
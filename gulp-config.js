module.exports = function() {
  var instanceRoot = "C:\\inetpub\\wwwroot\\demo.8.2.local";
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
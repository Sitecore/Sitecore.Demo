jQuery(function () {
  jQuery("head").on("favorites:removePage", function (event, itemID) {
    var panel = jQuery("#favoritesMenuItems");
    jQuery.ajax(
    {
      url: "/api/Favorites/RemovePage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
      }
    });
  });
  jQuery("head").on("favorites:addCurrentPage", function (event, itemID) {
    var panel = jQuery("#favoritesMenuItems");
    jQuery.ajax(
    {
      url: "/api/Favorites/AddPage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
      }
    });
  });
});
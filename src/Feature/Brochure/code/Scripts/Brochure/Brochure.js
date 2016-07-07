jQuery(function () {
  jQuery("head").on("brochure:removePage", function (event, itemID) {
    var panel = jQuery("#brochureItems");
    jQuery.ajax(
    {
      url: "/api/Brochure/RemovePage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
      }
    });
  });
  jQuery("head").on("brochure:addCurrentPage", function (event, itemID) {
    var panel = jQuery("#brochureItems");
    jQuery.ajax(
    {
      url: "/api/Brochure/AddPage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
      }
    });
  });
});
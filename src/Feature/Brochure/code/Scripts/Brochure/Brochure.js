jQuery(function () {
  function toggleButton() {
    var enabled = jQuery("#brochureItems table").length;
    var button = jQuery("#brochureMenuButton");
    if (enabled) {
      button.removeClass("disabled");
    }
    else {
      button.addClass("disabled");
    }
  }

  jQuery("head").on("brochure:removePage", function (event, itemID) {
    var panel = jQuery("#brochureItems");
    jQuery.ajax(
    {
      url: "/api/Brochure/RemovePage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
        toggleButton();
      }
    });
  });
  jQuery("head").on("brochure:addCurrentPage", function (event, itemID) {
    var panel = jQuery("#brochureItems");
    var button = jQuery("#brochureMenuButton");
    jQuery.ajax(
    {
      url: "/api/Brochure/AddPage?ItemID=" + itemID,
      method: "get",
      cache: false,
      success: function (data) {
        panel.replaceWith(data);
        toggleButton();
      }
    });
  });
  toggleButton();
});
var addressForm = (function() {
    "use strict";

    var init,
        selectedRegion = {},
        regionsByCountry,
        $countryDdl = $("#Country"),
        $regionDdl = $("#RegionDropDownList"),
        $regionDdlLabel = $("#region-dropdownlist-label"),
        $localityLabel = $("#locality-label"),
        $postalCode = $("#PostalCode"),
        $postalCodeLabel = $("#postalcode-label"),
        $form = $($countryDdl).closest("form"),
        $regionDdlGroup = $("#region-dropdownlist-group"),
        $regionTxtGroup = $("#region-textbox-group"),
        resources;

    //
    // Resources
    //

    resources = {
        regionLabelUS: "",
        localityLabelUS: "",
        postalCodeLabelUS: "",
        regionLabelCA: "",
        localityLabelCA: "",
        postalCodeLabelCA: "",
        localityLabelOther: "",
        postalCodeLabelOther: ""
    };


    //
    // Private functions
    //

    // Tests whether a country has regions associated with it.
    function countryHasRegions(countryRegions) {
        return countryRegions !== undefined && countryRegions !== null && countryRegions.length > 0;
    }

    // If true, show the region ddl. Otherwise, show the region textbox.
    function showRegionDdl(show) {
        if (show === true) {
            $regionDdlGroup.removeClass("hidden");
            $regionTxtGroup.addClass("hidden");
        } else {
            $regionDdlGroup.addClass("hidden");
            $regionTxtGroup.removeClass("hidden");
        }
    }


    //
    // jQuery event handlers
    //

    $("#Country").on("change", function() {
        var countryVal = $(this).val(),
            countryRegions = regionsByCountry[countryVal],
            prevSelectedRegion = selectedRegion[countryVal];

        if (countryHasRegions(countryRegions)) {
            // Clear any existing regions from the ddl.
            $regionDdl.empty();

            // Populate the regions ddl with the selected country's regions.
            $.each(countryRegions, function (ix, elm) {
                $regionDdl.append($("<option/>").val(elm.value).text(elm.text));
            });

            // If there is a previously selected state for this country, select it in the ddl.
            if ($.trim(prevSelectedRegion).length > 0) {
                $regionDdl.val(prevSelectedRegion);
            }

            showRegionDdl(true);
        } else {
            showRegionDdl(false);
        }

        // Used Used to determine whether there are any errors showing, without having to trigger validation first.
        var numInvalids = $form.validate().numberOfInvalids();

        if (countryVal === "US") {
            // Show US-specific labels on Region, Locality, and PostalCode.
            $regionDdlLabel.text(resources.regionLabelUS);
            $localityLabel.text(resources.localityLabelUS);
            $postalCodeLabel.text(resources.postalCodeLabelUS);

            $form.removeData("validator");
            $postalCode.attr("data-val-postalcoderequiredifcountry", "The " + resources.postalCodeLabelUS + " field is required.");
            $.validator.unobtrusive.parse(document);

            if (numInvalids > 0) {
                // Trigger validation to replace any error messages on PostalCode. Since we reparsed 
                //  the document, we have to revalidate the whole form.
                $form.valid();
            }
        } else if (countryVal == "CA") {
            // Show CA-specific lables on Region, Locality, and PostalCode.
            $regionDdlLabel.text(resources.regionLabelCA);
            $localityLabel.text(resources.localityLabelCA);
            $postalCodeLabel.text(resources.postalCodeLabelCA);

            $form.removeData("validator");
            $postalCode.attr("data-val-postalcoderequiredifcountry", "The " + resources.postalCodeLabelCA + " field is required.");
            $.validator.unobtrusive.parse(document);

            if (numInvalids > 0) {
                // Trigger validation to replace any error messages on PostalCode. Since we reparsed 
                //  the document, we have to revalidate the whole form.
                $form.valid();
            }
        } else {
            // Show generic labels on Region, Locality, and PostalCode.
            // The Region textbox label is static, and never changes. The Region DDL label is the only one that changes.
            $localityLabel.text(resources.localityLabelOther);
            $postalCodeLabel.text(resources.postalCodeLabelOther);

            // Trigger validation to remove any error messages on PostalCode.
            $form.validate().element($postalCode);
        }
    });

    // On state/province/region selection changed, persiste/restore the selected value so
    //  that showing/hiding the state/province/region doesn't wipe out the previously
    //  selected value.
    $("#RegionDropDownList").on("change", function () {
        var country = $countryDdl.val();

        selectedRegion[country] = $(this).val();
    });



    //
    // Public functions
    //

    init = function (options) {
        // Store the selected region for each country. This is the value at page load time.
        selectedRegion[options.initialCountry] = options.initialRegion;

        // A map of regions by country (Key: country; Value: array of regions). Currently only U.S. and Canada.
        regionsByCountry = options.regionsByCountry;
    };

    return {
        init: init,
        resources: resources
    };
})();

// jQuery validation and unobtrusive validation hookup for validating whether a PostalCode is required.
// If Country is US or CA, require a ZIP / Postal Code.
$.validator.addMethod("postalcoderequiredifcountry", function (value, element, params) {
    var countryId = $(element).attr("data-val-postalcoderequiredifcountry-countryprop");
    var countryVal = $("#" + countryId).val();

    if (countryVal === "US" || countryVal === "CA") {
        return $.trim(value).length > 0;
    }

    return true;
});

$.validator.unobtrusive.adapters.add("postalcoderequiredifcountry", {}, function (options) {
    // The value doesn't matter - we could assign anything. It just needs to be present in the rules dictionary.
    options.rules["postalcoderequiredifcountry"] = true;
    options.messages["postalcoderequiredifcountry"] = options.message;
});
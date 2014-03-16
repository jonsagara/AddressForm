/*jslint browser: true */
/*global $:false */
var addressForm = (function () {
    "use strict";

    var init,
        selectedRegion = {},
        regionsByCountry,
        $countryDdl = $("#Country"),
        $regionDdl = $("#RegionDropDownList"),
        $regionDdlLabel = $("#region-dropdownlist-label"),
        $locality = $("#Locality"),
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
        postalCodeLabelOther: "",
        localityRequiredErrorMessageUS: "",
        localityRequiredErrorMessageCA: "",
        localityRequiredErrorMessageOther: "",
        postalCodeRequiredErrorMessageUS: "",
        postalCodeRequiredErrorMessageCA: ""
    };


    //
    // Private functions
    //

    // Tests whether a country has regions associated with it. countryRegions, if defined and not null,
    //  is an array of regions for a particular country.
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

    // Update the validator's error message for postal code. If there are already errors visible on
    //  the form, re-validate the form to ensure that postal code shows up as required if it's not
    //  already populated.
    function updateValidator(postalCodeRequiredErrorMsg, localityRequiredErrorMsg) {
        // Used Used to determine whether there are any errors showing, without having to trigger validation first.
        var numInvalids = $form.validate().numberOfInvalids();

        $form.removeData("validator");
        $postalCode.attr("data-val-postalcoderequiredifcountry", postalCodeRequiredErrorMsg);
        $locality.attr("data-val-localityrequired", localityRequiredErrorMsg);
        $.validator.unobtrusive.parse(document);

        if (numInvalids > 0) {
            // Trigger validation to replace any error messages on PostalCode. Since we reparsed 
            //  the document, we have to revalidate the whole form.
            $form.valid();
        }
    }
    
    // Update the region, locality, and postal code labels for the newly-selected country. Also update
    //  the validator's error messages to show the appropiate label for postal code.
    function updateUi(country) {
        if (country === "US") {
            // Show US-specific labels on Region, Locality, and PostalCode.
            $regionDdlLabel.text(resources.regionLabelUS);
            $localityLabel.text(resources.localityLabelUS);
            $postalCodeLabel.text(resources.postalCodeLabelUS);

            updateValidator(resources.postalCodeRequiredErrorMessageUS, resources.localityRequiredErrorMessageUS);

        } else if (country === "CA") {
            // Show CA-specific lables on Region, Locality, and PostalCode.
            $regionDdlLabel.text(resources.regionLabelCA);
            $localityLabel.text(resources.localityLabelCA);
            $postalCodeLabel.text(resources.postalCodeLabelCA);

            updateValidator(resources.postalCodeRequiredErrorMessageCA, resources.localityRequiredErrorMessageCA);

        } else {
            // Show generic labels on Region, Locality, and PostalCode.
            // The Region textbox label is static, and never changes. The Region DDL label is the only one that changes.
            $localityLabel.text(resources.localityLabelOther);
            $postalCodeLabel.text(resources.postalCodeLabelOther);

            // Trigger validation to remove any error messages on PostalCode. Update the locality error message text.
            updateValidator("", resources.localityRequiredErrorMessageOther);
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

            // If there is a previously selected region for this country, select it in the ddl.
            if ($.trim(prevSelectedRegion).length > 0) {
                $regionDdl.val(prevSelectedRegion);
            }

            showRegionDdl(true);

        } else {
            showRegionDdl(false);
        }

        updateUi(countryVal);
    });

    // On state/province/region selection changed, persist/restore the selected value so
    //  that showing/hiding the state/province/region doesn't wipe out the previously
    //  selected value.
    $("#RegionDropDownList").on("change", function () {
        selectedRegion[$countryDdl.val()] = $(this).val();
    });



    //
    // Public functions
    //

    // Initialize with data from the view model.
    init = function (options) {
        // Store the selected region for each country. This is the value at page load time.
        selectedRegion[options.initialCountry] = options.initialRegion;

        // A JSON map of regions by country (Key: country; Value: array of regions). Currently only for U.S. and Canada.
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
    var countryId = $(element).attr("data-val-postalcoderequiredifcountry-countryprop"),
        countryVal = $("#" + countryId).val();

    if (countryVal === "US" || countryVal === "CA") {
        return $.trim(value).length > 0;
    }

    return true;
});

$.validator.unobtrusive.adapters.add("postalcoderequiredifcountry", {}, function (options) {
    // The value doesn't matter - we could assign anything. It just needs to be present in the rules dictionary.
    options.rules.postalcoderequiredifcountry = true;
    options.messages.postalcoderequiredifcountry = options.message;
});

// jQuery validation custom method for Locality. Locality is always required. We had to write
//  a custom validator in order to dynamically update the form labels and error messages.
$.validator.addMethod("localityrequired", function (value, element, params) {
    return $.trim(value).length > 0;
});

$.validator.unobtrusive.adapters.add("localityrequired", {}, function(options) {
    // The value doesn't matter - we could assign anything. It just needs to be present in the rules dictionary.
    options.rules.localityrequired = true;
    options.messages.localityrequired = options.message;
});
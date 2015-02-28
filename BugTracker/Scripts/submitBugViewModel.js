var submitViewModel = {
    Name: ko.observable(""),
    Description: ko.observable(""),

    save: function (formElement) {
        var jsonData = ko.toJSON(submitViewModel);
        $.ajax({
            type: "POST",
            url: "api/Bug",
            contentType: "application/json",
            data: jsonData,
            dataType: "json",
            sucess: function () { }
        });

    }
};


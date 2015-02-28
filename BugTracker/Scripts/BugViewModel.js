var bugViewModel = {
    BugID: ko.observable(),
    Name: ko.observable(),
    Description: ko.observable(),
    Assign: ko.observable("Gabby"),
    Catagory: ko.observable("Code"),

    load: function (id) {
        $.getJSON("/api/Bug/" + id, function (data) {
                bugViewModel.BugID(id);
                bugViewModel.Name(data.Name);
                bugViewModel.Description(data.Description);
        })
    }
};

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

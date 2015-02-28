var bugListViewModel = {
    Bugs: ko.observableArray(),

    load: function() {
        $.getJSON("/api/BugList", function (data) {
            $.each(data, function (bug) {
                bugListViewModel.Bugs.push({ BugUrl: "/ViewBug.html?bugid=" + this.BugID, Name: this.Name, Description: this.Description });
            });
        })
    }
};


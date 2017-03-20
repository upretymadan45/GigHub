var FollowingsController = function (followingService) {
    var button;
    var init = function (container) {
        $(container).on("click", ".js-toggle-follow", toggleFollow);
    }
    var toggleFollow = function (e) {
                button = $(e.target);
                var followeeId = button.attr("data-followee-id");
                if (button.hasClass("btn-default")) {
                    followingService.createFollowing(followeeId, done, fail);
                } else {
                    followingService.removeFollowing(followeeId, done, fail);
                }
        }

        var fail = function () {
            alert("Something wrong!");
        }

        var done = function () {
            var text = (button.text() == "Unfollow") ? "Follow?" : "Unfollow";
            button.toggleClass("btn-default").toggleClass("btn-info").text(text);
        }
    return {
        init:init
        }
} (FollowingService);


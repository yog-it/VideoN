/* Module Script */
var YogIT = YogIT || {};
var loadedScripts = [];

YogIT.VideoN = {
    playVideo: function (videoNId, options) {
        //YogIT.VideoN.disposePlayer(videoNId);
        videojs(videoNId, options);
    },
    disposePlayer: function (videoNId) {
        var player = videojs(videoNId);
        if (player) {
            player.dispose();
        }
    }
};
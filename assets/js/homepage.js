$(function () {
    var urlParams = new URLSearchParams(window.location.search);
    if (urlParams.has('query')) {
        $('.search-bar__input').val(urlParams.get('query'));
    }
});
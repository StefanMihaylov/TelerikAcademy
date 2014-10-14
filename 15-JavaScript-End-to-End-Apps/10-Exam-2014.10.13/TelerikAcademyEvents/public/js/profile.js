$(document).ready(function () {
    var $page = $('#page');
    $page.val(1);

    $('#next-page').on('click', function(){
        var page = $page.val();
        page++;
        $page.val(page);
        changePage(page)
    });

    $('#prev-page').on('click', function(){
        var page = $page.val();
        if(page > 1){
            page--;
        }
        $page.val(page);
        changePage(page)
    });

    $page.on('change', function(){
        var page = $page.val();
        changePage(page)
    });

    function changePage(page){
        data = {page: page};
        $.post('/active',data, function(response){});
    }
});

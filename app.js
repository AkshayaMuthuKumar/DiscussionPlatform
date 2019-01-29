
$(document).ready(function () {
    $('.btn').click(function () {
        $.ajax({
            type: "GET",
            url: "http://localhost:61559/api/Question",
            dataType: 'text json',
        }).done(function (data) {
            var books = JSON.parse(JSON.stringify(data));
            console.log(books);
            var html = '';
            $.each(books, function (index, value) {
              
                html += '<tr>';
                html += '<td>' + value.Id + '</td>';
                html += '<td>' + value.question + '</td>';
                html += '</tr>';
            });
            $('#questions > tbody').html(html);
        });
    });
});
$(document).ready(function () {
    $('#button').click(function () {
        $.ajax({
            type: "GET",
            url: "http://localhost:61559/api/Answer",
            dataType: 'text json',
        }).done(function (data) {
            var books = JSON.parse(JSON.stringify(data));
            console.log(books);
            var html = '';
            $.each(books, function (index, value) {
              
                html += '<tr>';
                html += '<td>' + value.Id + '</td>';
                html += '<td>' + value.answer + '</td>';
                html += '</tr>';
            });
            $('#answers > tbody').html(html);
        });
    });
});
  




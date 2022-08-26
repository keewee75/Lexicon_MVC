﻿//$(document).ready(function () {

//    $("#button1").click(function () {
//        $("#div1").load("/Ajax/ListPeople");
//    });

//});

$(document).ready(function () {

    $("#button1").click(function () {
        
        $.ajax({
            type: "GET",
            url: "/Ajax/ListPeople",
            dataType: "html",
            success: function (response) {

                $("#div1").html(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $("#personId").val("");
    });


    $("#button2").click(function () {
        var value = $("#personId").val();
        $.ajax({
            type: "POST",
            url: "/Ajax/PersonId",
            dataType: "html",
            data: { id: value },
            success: function (response) {
                
                $("#div1").html(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $("#personId").val("");
    });

    $("#button3").click(function () {
        var value = $("#personId").val();
        
        $.ajax({
            type: "POST",
            url: "/Ajax/PersonDelete",
            dataType: "html",
            data: { id: value },
            success: function (response) {
               
                $("#div1").html(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $("#personId").val("");
    });
});
$(document).ready(function () {
    var url = "http://localhost:51158/TransactionJSON.svc/GetTransactions";
    $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        success: function (data) {
            var returnData = data;
            //BuildTable(returnData);
            console.log("Ajax Call success.");
            console.log(returnData);
            
        },
        error: function (xhr) {
            console.log("Call failed.");
            console.log(xhr);
        }
    });
});

function BuildTable(returnData) {
    var htmlTable = [];
    htmlTable.push("<table class='table'>");

    for (i = 0; i < returnData.Length; i++) {
        htmlTable.push("<tr>");
        htmlTable.push("<td>" + returnData[i].DestinationAccountNumber + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionAccountNumber + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionAmount + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionDateTime + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionDescription + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionID + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionReference + "</td>");
        htmlTable.push("<td>" + returnData[i].TransactionType + "</td>");
        htmlTable.push("</tr>");
    }
    htmlTable.push("</table>");
    $("jsonTest").append(htmlTable.join(" "));
}

    
